using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ForceUser
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string LightsaberColor { get; set; }
        public List<byte> LightsaberForms { get; set; }
        public byte Rank { get; set; }
        public string RankName { get; set; }
        public bool IsDarkSide { get; set; }
        public string SideName { get; set; }

        public ForceUser() : this("Bob", "Human", 0, "Blue", new List<byte>() { 1 }, false) { }
        public ForceUser(string name, string species, byte rank, string lightsaberColor, List<byte> lightsaberForms, bool isDarkSide)
        {
            Name = name;
            Species = species;
            LightsaberColor = lightsaberColor;
            LightsaberForms = lightsaberForms;
            Rank = rank;
            IsDarkSide = isDarkSide;
            RankName = UpdateRankName();
        }
        
        public string About()
        {
            string formsAbout = string.Empty;
            for (int i = 0; i < LightsaberForms.Count; i++)
            {
                if (i > 0)
                    formsAbout += ", ";
                formsAbout += LightsaberForms[i].ToString();
            }
            return $"{Name} is a {Species} {RankName} with a {LightsaberColor} lightsaber.\nThey're trained in these lightsaber forms: {formsAbout}";
        }
        
        public void ChangeSides()
        {
            IsDarkSide = !IsDarkSide;
        }

        public string UpdateRankName()
        {
            string newRank;
            if (IsDarkSide) {
                switch (Rank)
                {
                    case 0:
                        newRank = "Sith";
                        break;
                    case 1:
                        newRank = "Sith Apprentice";
                        break;
                    case 2:
                        newRank = "Sith Lord";
                        break;
                    default:
                        newRank = "Sith";
                        break;
                }
            } else {
                switch (Rank)
                {
                    case 0:
                        newRank = "Jedi";
                        break;
                    case 1:
                        newRank = "Learnling";
                        break;
                    case 2:
                        newRank = "Padawan";
                        break;
                    case 3:
                        newRank = "Jedi Knight";
                        break;
                    case 4:
                        newRank = "Jedi Master";
                        break;
                    default:
                        newRank = "Jedi";
                        break;
                }
            }
            return newRank;
        }

        public void LearnForm(byte newForm)
        {
            if (newForm <= LightsaberForms.Last<byte>() || newForm > LightsaberForms.Last<byte>() + 1)
                return;
            LightsaberForms.Add(newForm);
        }
    }
}
