using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class ForceUserViewModel : INotifyPropertyChanged
    {
        public ForceUser forceUser { get; set; }

        public string Name { get { return this.forceUser.Name; } set { this.forceUser.Name = value; RaisePropertyChanged(); } }
        public string Species { get { return this.forceUser.Species; } set { this.forceUser.Species = value; RaisePropertyChanged(); } }
        public string LightsaberColor { get { return this.forceUser.LightsaberColor; } set { this.forceUser.LightsaberColor = value; RaisePropertyChanged(); } }
        public List<byte> LightsaberForms { get { return this.forceUser.LightsaberForms; } set { this.forceUser.LightsaberForms = value; RaisePropertyChanged(); } }
        public byte Rank { get { return this.forceUser.Rank; } set { this.forceUser.Rank = value; RaisePropertyChanged(); } }
        public string RankName { get { return this.forceUser.RankName; } set { this.forceUser.RankName = value; RaisePropertyChanged(); } }
        public bool IsDarkSide { get { return this.forceUser.IsDarkSide; } set { this.forceUser.IsDarkSide = value; RaisePropertyChanged(); } }
        public string SideName { get { return this.forceUser.SideName; } set { this.forceUser.SideName = value; RaisePropertyChanged(); } }

        public ForceUserViewModel() : this(new ForceUser("Bob", "Human", 0, "Blue", new List<byte>() { 1 }, false)) { }
        public ForceUserViewModel(ForceUser _user)
        {
            forceUser = _user;
            UpdateSide();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void UpdateSide()
        {
            if (IsDarkSide)
                SideName = "Dark";
            else
                SideName = "Light";

            if (Rank != 0)
            {
                Rank = 0;
                UpdateRankName();
            }
                
        }
        
        public void ChangeSides()
        {
            forceUser.ChangeSides();
            UpdateSide();
        }

        public void UpdateRankName()
        {
            RankName = forceUser.UpdateRankName();
        }

        public void LearnForm(byte newForm)
        {
            forceUser.LearnForm(newForm);
        }
    }
}
