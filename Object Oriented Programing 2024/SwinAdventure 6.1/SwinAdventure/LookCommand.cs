using System;
namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container;
            string itemId;

            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            else if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }
            else if (text[1].ToLower() != "at")
            {
                return "What do you want to look at?";
            }
            else if (text.Length == 5)
            {
                if (text[3].ToLower() != "in")
                {
                    return "What do you want to look in?";
                }
                else
                {
                    container = FetchContainer(p, text[4]);
                    itemId = text[2];
                    if (container == null) { return $"I cannot find the {text[4]}"; }
                }
            }
            else 
            {
                if (p != null)
                {
                    container = p;
                    itemId = text[2];
                }
                else { return "There is no Player"; }
            }

            return LookAtIn(itemId, container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (p != null)
            {
                return p.Locate(containerId) as IHaveInventory;
            }
            return null;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription;
            }
            else { return $"I can't find the {thingId}"; }
        }
    }
}

