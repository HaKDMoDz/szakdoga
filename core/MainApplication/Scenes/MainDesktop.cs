using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Squid;
using core.Domain;
using core.Windows;
using MainApplication.Windows;
using core.Service;
using core;

namespace MainApplication.Scenes
{
    public class MainDesktop : Desktop
    {
        private WindowService windowService;

        public WindowService WindowService
        {
            set
            {
                windowService = value;
            }
        }

        public MainDesktop(WindowService windowService)
        {
            this.windowService = windowService;
        }

        protected override void Initialize()
        {
            #region cursors

            Point cursorSize = new Point(32, 32);
            Point halfSize = cursorSize / 2;

            AddCursor(Cursors.Default, new Cursor { Texture = "Textures\\Cursors\\Arrow.png", Size = cursorSize, HotSpot = Point.Zero });
            AddCursor(Cursors.Link, new Cursor { Texture = "Textures\\Cursors\\Link.png", Size = cursorSize, HotSpot = Point.Zero });
            AddCursor(Cursors.Move, new Cursor { Texture = "Textures\\Cursors\\Move.png", Size = cursorSize, HotSpot = halfSize });
            AddCursor(Cursors.Select, new Cursor { Texture = "Textures\\Cursors\\Select.png", Size = cursorSize, HotSpot = halfSize });
            AddCursor(Cursors.SizeNS, new Cursor { Texture = "Textures\\Cursors\\SizeNS.png", Size = cursorSize, HotSpot = halfSize });
            AddCursor(Cursors.SizeWE, new Cursor { Texture = "Textures\\Cursors\\SizeWE.png", Size = cursorSize, HotSpot = halfSize });
            AddCursor(Cursors.HSplit, new Cursor { Texture = "Textures\\Cursors\\SizeNS.png", Size = cursorSize, HotSpot = halfSize });
            AddCursor(Cursors.VSplit, new Cursor { Texture = "Textures\\Cursors\\SizeWE.png", Size = cursorSize, HotSpot = halfSize });
            AddCursor(Cursors.SizeNESW, new Cursor { Texture = "Textures\\Cursors\\SizeNESW.png", Size = cursorSize, HotSpot = halfSize });
            AddCursor(Cursors.SizeNWSE, new Cursor { Texture = "Textures\\Cursors\\SizeNWSE.png", Size = cursorSize, HotSpot = halfSize });

            #endregion
            Styles();

            base.Initialize();
        }

        protected override void OnUpdate()
        {
            windowService.showWindow(WindowsName.PLAYERSTAT);

            base.OnUpdate();
        }

        private void Styles()
        {
            #region styles
            ControlStyle itemStyle = new ControlStyle();
            itemStyle.GridEnabled = true;
            itemStyle.Grid = new Margin(6);
            itemStyle.Texture = "Textures/button_hot.dds";
            itemStyle.Default.Texture = "Textures/button_default.dds";
            itemStyle.Pressed.Texture = "Textures/button_down.dds";
            itemStyle.SelectedPressed.Texture = "Textures/button_down.dds";
            itemStyle.Focused.Texture = "Textures/button_down.dds";
            itemStyle.SelectedFocused.Texture = "Textures/button_down.dds";
            itemStyle.Selected.Texture = "Textures/button_down.dds";
            itemStyle.SelectedHot.Texture = "Textures/button_down.dds";
            itemStyle.TextPadding = new Margin(10, 0, 10, 0);

            ControlStyle inputStyle = new ControlStyle();
            inputStyle.Texture = "Textures/input_default.dds";
            inputStyle.Hot.Texture = "Textures/input_focused.dds";
            inputStyle.Focused.Texture = "Textures/input_focused.dds";
            inputStyle.TextPadding = new Margin(8);
            inputStyle.GridEnabled = true;
            inputStyle.Grid = new Margin(6);

            ControlStyle buttonStyle = new ControlStyle();
            buttonStyle.Texture = "Textures/buttonBasic.dds";
            buttonStyle.Hot.Texture = "Textures/buttonOver.dds";
            buttonStyle.Pressed.Texture = "Textures/buttonClick.dds";
            buttonStyle.TextAlign = ContentAlignment.MiddleCenter;
            buttonStyle.GridEnabled = true;
            buttonStyle.Grid = new Margin(6);

            ControlStyle frameStyle = new ControlStyle();
            frameStyle.GridEnabled = true;
            frameStyle.Grid = new Margin(0);
            frameStyle.Texture = "Textures/background.dds";

            ControlStyle frame2Style = new ControlStyle();
            frame2Style.GridEnabled = true;
            frame2Style.Grid = new Margin(0);
            frame2Style.Texture = "Textures/tooltipBG.dds";


            ControlStyle vscrollTrackStyle = new ControlStyle();
            vscrollTrackStyle.GridEnabled = true;
            vscrollTrackStyle.Grid = new Margin(0, 3, 0, 3);
            vscrollTrackStyle.Texture = "Textures/scrollTrack.dds";

            ControlStyle vscrollButtonStyle = new ControlStyle();
            vscrollButtonStyle.GridEnabled = true;
            vscrollButtonStyle.Grid = new Margin(0, 4, 0, 4);
            vscrollButtonStyle.Texture = "Textures/scrollButton.dds";
            vscrollButtonStyle.Hot.Texture = "Textures/scrollButton.dds";
            vscrollButtonStyle.Pressed.Texture = "Textures/scrollButton.dds";

            ControlStyle vscrollUp = new ControlStyle();
            vscrollUp.Default.Texture = "Textures/scrollArrowUp.dds";
            vscrollUp.Hot.Texture = "Textures/scrollArrowUp.dds";
            vscrollUp.Pressed.Texture = "Textures/scrollArrowUp.dds";
            vscrollUp.Focused.Texture = "Textures/scrollArrowUp.dds";

            ControlStyle vscrollDown = new ControlStyle();
            vscrollDown.Default.Texture = "Textures/scrollArrowDown.dds";
            vscrollDown.Hot.Texture = "Textures/scrollArrowDown.dds";
            vscrollDown.Pressed.Texture = "Textures/scrollArrowDown.dds";
            vscrollDown.Focused.Texture = "Textures/scrollArrowDown.dds";

            ControlStyle hscrollTrackStyle = new ControlStyle();
            hscrollTrackStyle.GridEnabled = true;
            hscrollTrackStyle.Grid = new Margin(3, 0, 3, 0);
            hscrollTrackStyle.Texture = "Textures/hscroll_track.dds";

            ControlStyle hscrollButtonStyle = new ControlStyle();
            hscrollButtonStyle.GridEnabled = true;
            hscrollButtonStyle.Grid = new Margin(4, 0, 4, 0);
            hscrollButtonStyle.Texture = "Textures/hscroll_button.dds";
            hscrollButtonStyle.Hot.Texture = "Textures/hscroll_button_hot.dds";
            hscrollButtonStyle.Pressed.Texture = "Textures/hscroll_button_down.dds";

            ControlStyle hscrollUp = new ControlStyle();
            hscrollUp.Default.Texture = "Textures/hscrollUp_default.dds";
            hscrollUp.Hot.Texture = "Textures/hscrollUp_hot.dds";
            hscrollUp.Pressed.Texture = "Textures/hscrollUp_down.dds";
            hscrollUp.Focused.Texture = "Textures/hscrollUp_hot.dds";


            ControlStyle checkButtonStyle = new ControlStyle();
            checkButtonStyle.Default.Texture = "Textures/checkbox_default.dds";
            checkButtonStyle.Hot.Texture = "Textures/checkbox_hot.dds";
            checkButtonStyle.Pressed.Texture = "Textures/checkbox_down.dds";
            checkButtonStyle.Checked.Texture = "Textures/checkbox_checked.dds";
            checkButtonStyle.CheckedFocused.Texture = "Textures/checkbox_checked_hot.dds";
            checkButtonStyle.CheckedHot.Texture = "Textures/checkbox_checked_hot.dds";
            checkButtonStyle.CheckedPressed.Texture = "Textures/checkbox_down.dds";

            ControlStyle comboLabelStyle = new ControlStyle();
            comboLabelStyle.TextPadding = new Margin(10, 0, 0, 0);
            comboLabelStyle.Default.Texture = "Textures/combo_default.dds";
            comboLabelStyle.Hot.Texture = "Textures/combo_hot.dds";
            comboLabelStyle.Pressed.Texture = "Textures/combo_down.dds";
            comboLabelStyle.Focused.Texture = "Textures/combo_hot.dds";
            comboLabelStyle.GridEnabled = true;
            comboLabelStyle.Grid = new Margin(6, 0, 0, 0);

            ControlStyle comboButtonStyle = new ControlStyle();
            comboButtonStyle.Default.Texture = "Textures/combo_button_default.dds";
            comboButtonStyle.Hot.Texture = "Textures/combo_button_hot.dds";
            comboButtonStyle.Pressed.Texture = "Textures/combo_button_down.dds";
            comboButtonStyle.Focused.Texture = "Textures/combo_button_hot.dds";

            ControlStyle labelStyle = new ControlStyle();
            labelStyle.TextAlign = ContentAlignment.MiddleCenter;
            labelStyle.TextColor = Game.Globals.Colorkey(MTV3D65.CONST_TV_COLORKEY.TV_COLORKEY_BLACK); //Game.Globals.RGBA(255, 255, 255, 0);

            ControlStyle skillLabelStyle = new ControlStyle();
            skillLabelStyle.TextAlign = ContentAlignment.MiddleLeft;
            //skillLabelStyle.Font = "Abaddon™";            
            skillLabelStyle.TextColor = Game.Globals.Colorkey(MTV3D65.CONST_TV_COLORKEY.TV_COLORKEY_BLACK);
            GUI.AddStyle("skillLabel", skillLabelStyle);

            ControlStyle slotStyle = new ControlStyle();
            slotStyle.Texture = "Textures/slot.dds";
            slotStyle.TextAlign = ContentAlignment.MiddleCenter;
            slotStyle.GridEnabled = true;
            slotStyle.Grid = new Margin(6);

            ControlStyle headerStyle = new ControlStyle();
            headerStyle.Texture = "Textures/windowHeadBasic.dds";
            headerStyle.Hot.Texture = "Textures/windowHeadOver.dds";
            headerStyle.Pressed.Texture = "Textures/windowHeadClick.dds";
            headerStyle.TextAlign = ContentAlignment.MiddleCenter;
            headerStyle.GridEnabled = true;
            headerStyle.Grid = new Margin(6);

            ControlStyle closeStyle = new ControlStyle();
            closeStyle.Texture = "Textures/closeBasic.dds";
            closeStyle.Hot.Texture = "Textures/closeOver.dds";
            closeStyle.Pressed.Texture = "Textures/closeClick.dds";
            closeStyle.TextAlign = ContentAlignment.MiddleCenter;
            closeStyle.GridEnabled = true;
            closeStyle.Grid = new Margin(6);

            //ItemIcons(ItemName.Cobalt);
            //ItemIcons(ItemName.AnimalSkin);
            //ItemIcons(ItemName.CobaltPowder);
            //ItemIcons(ItemName.CobaltSword);
            //ItemIcons(ItemName.DestroyerAxe);
            //ItemIcons(ItemName.Basalt);
            //ItemIcons(ItemName.BasaltPowder);
            //ItemIcons(ItemName.BasaltHammer);
            //ItemIcons(ItemName.BoneBoots);
            //ItemIcons(ItemName.BoneChest);
            //ItemIcons(ItemName.BoneGloves);
            //ItemIcons(ItemName.BoneHelm);
            //ItemIcons(ItemName.BoneLShoulder);
            //ItemIcons(ItemName.BoneRShoulder);
            //ItemIcons(ItemName.Bow);
            //ItemIcons(ItemName.Carbon);
            //ItemIcons(ItemName.EmptyArmor);
            //ItemIcons(ItemName.EmptyBoots);
            //ItemIcons(ItemName.EmptyGloves);
            //ItemIcons(ItemName.EmptyHelmet);
            //ItemIcons(ItemName.EmptyShield);
            //ItemIcons(ItemName.EmptyWeapon);
            //ItemIcons(ItemName.EmptyLShoulder);
            //ItemIcons(ItemName.EmptyRShoulder);
            //ItemIcons(ItemName.Glue);
            //ItemIcons(ItemName.Gold);
            //ItemIcons(ItemName.Hardener);
            //ItemIcons(ItemName.Iron);
            //ItemIcons(ItemName.IronOre);
            //ItemIcons(ItemName.Leather);
            //ItemIcons(ItemName.LizardmanShield);
            //ItemIcons(ItemName.Lubricant);
            //ItemIcons(ItemName.Mithrill);
            //ItemIcons(ItemName.MithrillOre);
            //ItemIcons(ItemName.Shield);
            //ItemIcons(ItemName.SlayerEdge);
            //ItemIcons(ItemName.SmallHealingPotion);
            //ItemIcons(ItemName.SmallManaPotion);
            //ItemIcons(ItemName.Steel);
            //ItemIcons(ItemName.Sword);
            //ItemIcons(ItemName.TalonShield);
            //ItemIcons(ItemName.Textile);
            //ItemIcons(ItemName.Thread);
            //ItemIcons(ItemName.HomunculusRobe);
            //ItemIcons(ItemName.HomunculusGloves);
            //ItemIcons(ItemName.HomunculusBoots);
            //ItemIcons(ItemName.MagicSword);
            //ItemIcons(SkillName.Hurricane.ToString());
            //ItemIcons(SkillName.TameBeast.ToString());
            //ItemIcons(SkillName.ServitorHeal.ToString());
            //ItemIcons(ItemName.ScaledLeatherHelmet);
            //ItemIcons(ItemName.ScaledLeatherGloves);
            //ItemIcons(ItemName.ScaledLeatherBoots);
            //ItemIcons(ItemName.ScaledLeatherArmor);

            //ItemIconsPNG(ItemName.PlateArmor);
            //ItemIconsPNG(ItemName.PlateBoots);
            //ItemIconsPNG(ItemName.PlateGloves);
            //ItemIconsPNG(ItemName.HeavyPlateArmor);
            //ItemIconsPNG(ItemName.HeavyPlateBoots);
            //ItemIconsPNG(ItemName.HeavyPlateGloves);

            //ItemIconsPNG(ItemName.BeetleShield);
            //ItemIconsPNG(ItemName.WoodenShield);
            //ItemIconsPNG(ItemName.BrokenShield);

            //ItemIconsPNG(ItemName.BoneBoots);
            //ItemIconsPNG(ItemName.BoneArmor);
            //ItemIconsPNG(ItemName.BoneGloves);
            //ItemIconsPNG(ItemName.BoneHelm);

            //ItemIcons("slot");

            ItemIcons("tooltipBG");
            //ItemIcons("SkillCastingProgressBar");
            //ItemIcons("SkillCastingLine");
            //ItemIcons("tooltipBG");
            //ItemIcons(SkillName.BasicHit.ToString());
            //ItemIconsPNG(SkillName.SelfHeal.ToString());

            //ControlStyle infoTextArea = new ControlStyle();
            //infoTextArea.Texture = "Textures/infoTextArea_def.dds";
            //infoTextArea.Hot.Texture = "Textures/infoTextArea_focused.dds";
            //infoTextArea.Focused.Texture = "Textures/infoTextArea_focused.dds";
            //infoTextArea.TextPadding = new Margin(8);
            //infoTextArea.GridEnabled = true;
            //infoTextArea.Grid = new Margin(6);
            //GUI.AddStyle("infoTextArea", infoTextArea);



            //CreateCreatureIconStyleDDS(CreaturesIDName.Dwarf);
            //CreateCreatureIconStyleDDS(CreaturesIDName.DwarfChief);
            //CreateCreatureIconStyleDDS(CreaturesIDName.EarthElemental);
            //CreateCreatureIconStyleDDS(CreaturesIDName.Troll);

            //CreateCreatureIconStylePNG(CreaturesIDName.GoblinWarrior);

            //ItemIcons("Map/MapTexture");


            //LabelStyles("blackFont");
            //LabelStyles("blackFontLeft");

            //ControlStyle blackFontLeft = new ControlStyle();
            //blackFontLeft.TextAlign = ContentAlignment.TopLeft;
            //blackFontLeft.TextColor = Game.Globals.Colorkey(MTV3D65.CONST_TV_COLORKEY.TV_COLORKEY_BLACK); //Game.Globals.RGBA(255, 255, 255, 0);
            //GUI.AddStyle("blackFontLeft", blackFontLeft);



            //Font font = new Font();
            //font.Family = "Fonts/abaddon.TTF";
            //font.Name = "abaddon";
            //font.International = true;
            //font.Size = 14;




            //ControlStyle helpWinText = new ControlStyle();
            //helpWinText.TextAlign = ContentAlignment.MiddleCenter;
            //helpWinText.TextColor = Game.Globals.RGBA(255, 255, 255, 1);
            ////helpWinText.Font = "Abaddon™";            
            ////helpWinText.Font = "abaddon";
            ////helpWinText.Font = "abaddon"; 
            //GUI.AddStyle("helpWinText", helpWinText);


            GUI.AddStyle("item", itemStyle);
            GUI.AddStyle("textbox", inputStyle);
            GUI.AddStyle("button", buttonStyle);
            GUI.AddStyle("frame", frameStyle);
            GUI.AddStyle("frame2", frame2Style);
            GUI.AddStyle("checkBox", checkButtonStyle);
            GUI.AddStyle("comboLabel", comboLabelStyle);
            GUI.AddStyle("comboButton", comboButtonStyle);
            GUI.AddStyle("scrollTrack", vscrollTrackStyle);
            GUI.AddStyle("scrollButton", vscrollButtonStyle);
            GUI.AddStyle("scrollUp", vscrollUp);
            GUI.AddStyle("scrollDown", vscrollDown);
            GUI.AddStyle("hscrollTrack", hscrollTrackStyle);
            GUI.AddStyle("hscrollButton", hscrollButtonStyle);
            GUI.AddStyle("hscrollUp", hscrollUp);
            GUI.AddStyle("header", headerStyle);
            GUI.AddStyle("close", closeStyle);
            //GUI.AddStyle(SkillName.IncMaxHp.ToString(), IncMaxHpTexture);
            //GUI.AddStyle(SkillName.IncPAttk.ToString(), IncPAttkTexture);
            //GUI.AddStyle(SkillName.IncPdef.ToString(), IncPdefTexture);
            //GUI.AddStyle(SkillName.ServitorHeal.ToString(), ServitorHealTexture);
            //GUI.AddStyle(SkillName.SummonWolf.ToString(), SummWolf);
            //GUI.AddStyle(SkillName.EmptySkill.ToString(), NoneSkillText);
            //GUI.AddStyle(SkillName.Hurricane.ToString(), HurricaneTexture);


            #endregion
        }

        private void ItemIcons(string name)
        {
            ControlStyle itemText = new ControlStyle();
            itemText.Texture = "Textures/" + name + ".dds";
            GUI.AddStyle(name, itemText);
        }
        private void ItemIcons(ItemName name)
        {
            ItemIcons(name.ToString());
        }
    }
}
