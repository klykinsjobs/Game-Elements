using System.ComponentModel;

namespace Game_Elements
{
    public class ResearchTree
    {
        public BindingList<ResearchNode> ResearchNodes { get; set; } = [];
        public Queue<string> Queue { get; set; } = [];

        public void EnqueueResearch(string researchNodeName)
        {
            // Look up the research node by name
            var researchNode = ResearchNodes.FirstOrDefault(n => n.Name == researchNodeName);

            // Proceed if the node exists and hasn't been researched yet
            if (researchNode != null && !researchNode.Researched)
            {
                // Avoid adding the same research node to the queue more than once
                if (!Queue.Contains(researchNode.Name))
                {
                    // Ensure all prerequisites are queued first
                    foreach (var prerequisite in researchNode.Prerequisites)
                    {
                        var prerequisiteResearchNode = ResearchNodes.FirstOrDefault(n => n.Name == prerequisite);

                        // Recursively enqueue unmet prerequisites
                        if (prerequisiteResearchNode != null && !prerequisiteResearchNode.Researched)
                            EnqueueResearch(prerequisiteResearchNode.Name);
                    }

                    // After any prerequisites have been queued, enqueue this research node
                    Queue.Enqueue(researchNode.Name);
                }
            }
        }

        public void Tick(int playerIndex)
        {
            if (GameManager.Players[playerIndex].Inventory.Research > 0)
            {
                // Continue as long as there are items in the research queue
                while (Queue.Count > 0)
                {
                    // Look up the next research node in the queue by name
                    var researchNode = ResearchNodes.FirstOrDefault(n => n.Name == Queue.Peek());

                    if (researchNode != null)
                    {
                        // Determine how much research can be applied to this node, without exceeding it's target amount
                        int min = Math.Min(GameManager.Players[playerIndex].Inventory.Research, researchNode.Target - researchNode.Progress);

                        // Remove research
                        Loot lootToRemove = new() { LootQuantities = new Dictionary<LootType, int> { { LootType.Research, min } } };
                        if (GameManager.Players[playerIndex].Inventory.TryRemove(playerIndex, lootToRemove, true))
                        {
                            // Apply research amount to node
                            researchNode.Progress += min;

                            // If the node is fully researched, mark it as complete and remove it from the queue
                            if (researchNode.Progress >= researchNode.Target)
                            {
                                Queue.Dequeue();
                                researchNode.Researched = true;

                                // Update quests and statistics
                                if (GameManager.CurrentPlayer != null && playerIndex == GameManager.Players.IndexOf(GameManager.CurrentPlayer))
                                {
                                    OutputService.Write(true,
                                        [
                                            new("Researched: ", Properties.Settings.Default.PrimaryForeColor, true, false, false),
                                            new($"{researchNode.Name}", Properties.Settings.Default.PrimaryForeColor)
                                        ]);
                                }

                                // Add modifier
                                GameManager.Players[playerIndex].Modifiers.Add(researchNode.Modifier);

                                // Update quests and statistics
                                GameManager.TryQuestProgress(playerIndex, QuestType.ResearchNode, 1);
                                GameManager.Players[playerIndex].Statistics.NodesResearched += 1;
                            }
                            else
                            {
                                // Not enough research to complete this node
                                break;
                            }
                        }
                        else
                        {
                            // Failed to remove research from inventory
                            break;
                        }
                    }
                    else
                    {
                        // Queue references a node that doesn't exist
                        break;
                    }
                }
            }
        }
    }
}