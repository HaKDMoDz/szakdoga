using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Windows;
using Squid;
using core.Domain;

namespace MainApplication.Windows
{
    public class PlayerStatisticsWindow : WindowsBase
    {
        Label lbName, lbHP, lbMP, lbPAttk, lbMAttk, lbLvl, lbArmor, lbBoots, lbGloves, lbHelmet, lbShield, lbWeap, lbPdef, lbMDef, lbAttSpeed, lbCastSpeed;

        private Statistics statistics;

        private Statistics Statistics
        {
            set
            {
                statistics = value;
            }
        }

        public PlayerStatisticsWindow(Desktop desktop) : base(desktop) { }

        public override void initializeComponent()
        {
            initWindow();

            lbName = createLabel("Name: ", new Point(15, 35));
            lbHP = createLabel("HP: ", new Point(15, 50));
            lbMP = createLabel("MP: ", new Point(15, 65));
            lbPAttk = createLabel("PAttck: ", new Point(15, 80));
            lbMAttk = createLabel("MAttck: ", new Point(15, 95));
            lbLvl = createLabel("Level: ", new Point(15, 110));
        }

        private void initWindow()
        {
            Size = new Squid.Point(300, 300);
            Position = new Squid.Point(100, 100);
            Style = "frame";
            setWindowTitle("Statistics");
            Resizable = false;
            Parent = this;
        }

        public void RefreshData()
        {
            //CreatureBase target = (CreatureBase)GlobalFields.PlayerManager.Target;
            //lbWeap.Text = "Weap: " + statistics.UseWeapon.Name;
            //lbShield.Text = "Shield: " + PlayerManager.UseShield.Name;
            //lbPAttk.Text = "Patt: " + GlobalFields.PlayerManager.PAttack + "";
            //lbMP.Text = "MP: " + statistics MaxManaPoint + "/" + GlobalFields.PlayerManager.ManaPoint;
            //lbMAttk.Text = "Matt: " + GlobalFields.PlayerManager.MAttack + "";
            //lbLvl.Text = "lvl: " + GlobalFields.PlayerManager.Level + "";
            lbHP.Text = "Hp: " + statistics.MaxHealthPoint + "/" + statistics.HealthPoint;
            //lbHelmet.Text = "Helmet: " + GlobalFields.PlayerManager.UseHelmet.Name;
            //lbGloves.Text = "Gloves: " + GlobalFields.PlayerManager.UseGloves.Name;
            //lbBoots.Text = "Boots: " + GlobalFields.PlayerManager.UseBoots.Name;
            //lbArmor.Text = "Armor: " + GlobalFields.PlayerManager.UseArmor.Name;
            //lbMDef.Text = "Mdef: " + GlobalFields.PlayerManager.MDeffense + "";
            //lbPdef.Text = "Pdef: " + GlobalFields.PlayerManager.PDeffense + "";
            //lbCastSpeed.Text = "Cast speed: " + GlobalFields.PlayerManager.CastSpeed + "";
            //lbAttSpeed.Text = "Att speed: " + GlobalFields.PlayerManager.AttackSpeed + "";
        }

        private Label createLabel(String text, Point position, Point size)
        {
            Label label = new Label();
            label.Style = "labelStyle";
            label.Text = text;
            label.Size = size;
            label.Position = position;
            label.Parent = this;

            return label;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }

        private Label createLabel(String text, Point position)
        {
            return createLabel(text, position, new Point(122, 35));
        }
    }
}
