﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbx2Source.Web
{
    public class LegacyAssets
    {
        private static Dictionary<string, long> Database = new Dictionary<string, long>()
        {
            {"rbxasset://textures/A_Key_dn.png", 12222317},
            {"rbxasset://textures/A_Key.png", 12222308},
            {"rbxasset://textures/BaseballCapRed.png", 12222323},
            {"rbxasset://textures/bombtex.png", 12222348},
            {"rbxasset://textures/Bomb.png", 12222334},
            {"rbxasset://textures/CameraPanRight_ovr.png", 12222439},
            {"rbxasset://textures/CameraPanRight_dn.png", 12222430},
            {"rbxasset://textures/CameraPanRight.png", 12222420},
            {"rbxasset://textures/CameraPanLeft_ovr.png", 12222414},
            {"rbxasset://textures/CameraPanLeft_dn.png", 12222403},
            {"rbxasset://textures/CameraPanLeft.png", 12222388},
            {"rbxasset://textures/CameraCenter_ovr.png", 12222373},
            {"rbxasset://textures/CameraCenter_ds.png", 12222368},
            {"rbxasset://textures/CameraCenter_dn.png", 12222361},
            {"rbxasset://textures/CameraCenter.png", 12222351},
            {"rbxasset://textures/Character.png", 12222542},
            {"rbxasset://textures/CloneWandTexture.png", 12222613},
            {"rbxasset://textures/Controller1.png", 12222618},
            {"rbxasset://textures/Controller1_ds.png", 12222651},
            {"rbxasset://textures/Controller1_dn.png", 12222643},
            {"rbxasset://textures/Controller1_ovr.png", 12222658},
            {"rbxasset://textures/Controller1Tool_dn.png", 12222631},
            {"rbxasset://textures/Controller1Tool.png", 12222625},
            {"rbxasset://textures/Controller2_ovr.png", 12222710},
            {"rbxasset://textures/Controller2_ds.png", 12222700},
            {"rbxasset://textures/Controller2_dn.png", 12222687},
            {"rbxasset://textures/Controller2Tool_dn.png", 12222685},
            {"rbxasset://textures/Controller2Tool.png", 12222677},
            {"rbxasset://textures/Controller2.png", 12222671},
            {"rbxasset://textures/ControllerAI2Tool_dn.png", 12222736},
            {"rbxasset://textures/ControllerAI2Tool.png", 12222733},
            {"rbxasset://textures/ControllerAI1Tool_dn.png", 12222726},
            {"rbxasset://textures/ControllerAI1Tool.png", 12222720},
            {"rbxasset://textures/ControllerPanel.png", 12222767},
            {"rbxasset://textures/ControllerNoneTool_dn.png", 12222755},
            {"rbxasset://textures/ControllerNoneTool.png", 12222742},
            {"rbxasset://textures/D_Key_dn.png", 12222831},
            {"rbxasset://textures/D_Key.png", 12222825},
            {"rbxasset://textures/Down_key_dn.png", 12222788},
            {"rbxasset://textures/Down_key.png", 12222782},
            {"rbxasset://textures/Detonator.png", 12222773},
            {"rbxasset://textures/DropperTool_dn.png", 12222819},
            {"rbxasset://textures/DropperTool.png", 12222808},
            {"rbxasset://textures/DropperCursor.png", 12222805},
            {"rbxasset://textures/FireWand.png", 12222892},
            {"rbxasset://textures/FillTool_dn.png", 12222881},
            {"rbxasset://textures/FillTool.png", 12222872},
            {"rbxasset://textures/FlatTool_dn.png", 12223363},
            {"rbxasset://textures/FlatTool.png", 12223332},
            {"rbxasset://textures/Flamethrower.png", 12222937},
            {"rbxasset://textures/Gun.png", 12223438},
            {"rbxasset://textures/GlueCursor.png", 12223406},
            {"rbxasset://textures/Glue.png", 12223401},
            {"rbxasset://textures/HalloweenSkull.png", 12223869},
            {"rbxasset://textures/HalloweenRocket.png", 12223859},
            {"rbxasset://textures/HalloweenPumpkin.png", 12223503},
            {"rbxasset://textures/HalloweenGhost.png", 12223487},
            {"rbxasset://textures/HalloweenAsylum.png", 12223472},
            {"rbxasset://textures/Hammer.png", 12223874},
            {"rbxasset://textures/hammertex128.png", 12223896},
            {"rbxasset://textures/HopperPanel.png", 12229455},
            {"rbxasset://textures/H_Key_dn.png", 12223925},
            {"rbxasset://textures/H_Key.png", 12223920},
            {"rbxasset://textures/J_Key_dn.png", 12223934},
            {"rbxasset://textures/J_Key.png", 12229462},
            {"rbxasset://textures/K_Key_dn.png", 12223944},
            {"rbxasset://textures/K_Key.png", 12223938},
            {"rbxasset://textures/Laser.png", 12223948},
            {"rbxasset://textures/Left_key_dn.png", 12223985},
            {"rbxasset://textures/Left_key.png", 12223979},
            {"rbxasset://textures/LeftMotorTool_dn.png", 12223977},
            {"rbxasset://textures/LeftMotorTool.png", 12223968},
            {"rbxasset://textures/LeftMotorFastTool_dn.png", 12223964},
            {"rbxasset://textures/LeftMotorFastTool.png", 12223954},
            {"rbxasset://textures/MedKit.png", 12223996},
            {"rbxasset://textures/Multirocket.png", 12224010},
            {"rbxasset://textures/MultiSelection.png", 12224012},
            {"rbxasset://textures/PaintballGunTex128.png", 12224033},
            {"rbxasset://textures/PaintballIcon.png", 12229471},
            {"rbxasset://textures/pirate.png", 12229478},
            {"rbxasset://textures/PoliceCap.png", 12224039},
            {"rbxasset://textures/Right_key_dn.png", 12224062},
            {"rbxasset://textures/Right_key.png", 12224057},
            {"rbxasset://textures/Rocket.png", 17598704},
            {"rbxasset://textures/RocketBoots.png", 11900767},
            {"rbxasset://textures/rocketlaunchertex.png", 12224070},
            {"rbxasset://textures/S_Key_dn.png", 12224227},
            {"rbxasset://textures/S_Key.png", 12224224},
            {"rbxasset://textures/SlingshotTexture.png", 12224131},
            {"rbxasset://textures/Slingshot.png", 12224122},
            {"rbxasset://textures/Snowball.png", 12224133},
            {"rbxasset://textures/Snowflake.png", 12224137},
            {"rbxasset://textures/sombrero.png", 12224141},
            {"rbxasset://textures/Superball.png", 12224172},
            {"rbxasset://textures/SurfacePanel.png", 12224175},
            {"rbxasset://textures/SwordTexture.png", 12224218},
            {"rbxasset://textures/Sword128.png", 12224215},
            {"rbxasset://textures/test_texture.JPG", 12224240},
            {"rbxasset://textures/test2_texture.JPG", 12224234},
            {"rbxasset://textures/TopHatPurple.png", 12229488},
            {"rbxasset://textures/treetex.png", 12224246},
            {"rbxasset://textures/TrowelTexture.png", 12229499},
            {"rbxasset://textures/U_Key_dn.png", 12224281},
            {"rbxasset://textures/U_Key.png", 12224274},
            {"rbxasset://textures/Up_key_dn.png", 12224267},
            {"rbxasset://textures/Up_key.png", 12224262},
            {"rbxasset://textures/VelocityTool_ovr.png", 12224309},
            {"rbxasset://textures/VelocityTool_dn.png", 12224289},
            {"rbxasset://textures/VelocityTool.png", 12224285},
            {"rbxasset://textures/VelocityTool_ds.png", 12229500},
            {"rbxasset://textures/viking.png", 12224312},
            {"rbxasset://textures/W_Key_dn.png", 12224353},
            {"rbxasset://textures/W_Key.png", 12224347},
            {"rbxasset://textures/Wall.png", 12224320},
            {"rbxasset://sounds/Rocket whoosh 01.wav", 12222095},
            {"rbxasset://sounds/paintball.wav", 11900833},
            {"rbxasset://sounds/Short spring sound.wav", 12222124},
            {"rbxasset://sounds/Rocket shot.wav", 12222084},
            {"rbxasset://sounds/glassbreak.wav", 12222005},
            {"rbxasset://sounds/Launching rocket.wav", 12222065},
            {"rbxasset://sounds/Shoulder fired rocket.wav", 12222132},
            {"rbxasset://sounds/HalloweenThunder.wav", 12222030},
            {"rbxasset://sounds/HalloweenLightning.wav", 12222019},
            {"rbxasset://sounds/HalloweenGhost.wav", 12229501},
            {"rbxasset://icons/surface_ds.png", 23576067},
            {"rbxasset://icons/surface.png", 23576066},
            {"rbxasset://icons/rotate.png", 23576065},
            {"rbxasset://icons/color_sel.png", 23576064},
            {"rbxasset://icons/color.png", 23576062},
            {"rbxasset://icons/insert.png", 23576057},
            {"rbxasset://icons/freemove_ovr.png", 23576055},
            {"rbxasset://icons/surface_sel.png", 23575961},
            {"rbxasset://icons/surface_ovr.png", 23575960},
            {"rbxasset://icons/rotate_ovr.png", 23575949},
            {"rbxasset://icons/rotate_ds.png", 23575946},
            {"rbxasset://icons/resize_sel.png", 23575942},
            {"rbxasset://icons/resize_ovr.png", 23575941},
            {"rbxasset://icons/resize_ds.png", 23575940},
            {"rbxasset://icons/resize.png", 23575937},
            {"rbxasset://icons/color_ovr.png", 23575933},
            {"rbxasset://icons/color_ds.png", 23575928},
            {"rbxasset://icons/material_sel.png", 23575919},
            {"rbxasset://icons/material_ovr.png", 23575918},
            {"rbxasset://icons/material_ds.png", 23575917},
            {"rbxasset://icons/material.png", 23575916},
            {"rbxasset://icons/lock_sel.png", 23575914},
            {"rbxasset://icons/lock_ovr.png", 23575912},
            {"rbxasset://icons/lock_ds.png", 23575909},
            {"rbxasset://icons/lock.png", 23575908},
            {"rbxasset://icons/insert_sel.png", 23575907},
            {"rbxasset://icons/insert_ovr.png", 23575906},
            {"rbxasset://icons/insert_ds.png", 23575905},
            {"rbxasset://icons/freemove_sel.png", 23575901},
            {"rbxasset://icons/freemove_ds.png", 23575889},
            {"rbxasset://icons/freemove.png", 23575887},
            {"rbxasset://icons/delete_sel.png", 23575885},
            {"rbxasset://icons/delete_ovr.png", 23575884},
            {"rbxasset://icons/delete_ds.png", 23575883},
            {"rbxasset://icons/delete.png", 23575880},
            {"rbxasset://icons/configure_sel.png", 23575879},
            {"rbxasset://icons/configure_ovr.png", 23575878},
            {"rbxasset://icons/configure_ds.png", 23575877},
            {"rbxasset://icons/configure.png", 23575875},
            {"rbxasset://icons/axismove_sel.png", 23575874},
            {"rbxasset://icons/axismove_ovr.png", 23575873},
            {"rbxasset://icons/axismove_ds.png", 23575872},
            {"rbxasset://icons/axismove.png", 23575871},
            {"rbxasset://icons/anchor_sel.png", 23575870},
            {"rbxasset://icons/anchor_ovr.png", 23575869},
            {"rbxasset://icons/anchor_ds.png", 23575867},
            {"rbxasset://icons/anchor.png", 23575866},
            {"rbxasset://icons/surface_dn.png", 23629198},
            {"rbxasset://icons/rotate_dn.png", 23629197},
            {"rbxasset://icons/resize_dn.png", 23629194},
            {"rbxasset://icons/color_dn.png", 23629193},
            {"rbxasset://icons/material_dn.png", 23629192},
            {"rbxasset://icons/lock_dn.png", 23629189},
            {"rbxasset://icons/insert_dn.png", 23629186},
            {"rbxasset://icons/freemove_dn.png", 23629182},
            {"rbxasset://icons/delete_dn.png", 23629179},
            {"rbxasset://icons/configure_dn.png", 23629177},
            {"rbxasset://icons/axismove_dn.png", 23629176},
            {"rbxasset://icons/anchor_dn.png", 23629212},
            {"rbxasset://fonts/BaseballCap.mesh", 12220916},
            {"rbxasset://fonts/clonewand.mesh", 12221344},
            {"rbxasset://fonts/fusedgirl.mesh", 12221423},
            {"rbxasset://fonts/girlhair.mesh", 12221431},
            {"rbxasset://fonts/hammer.mesh", 12221451},
            {"rbxasset://fonts/NinjaMask.mesh", 12221524},
            {"rbxasset://fonts/paintballgun.mesh", 11900867},
            {"rbxasset://fonts/pawn.mesh", 12221585},
            {"rbxasset://fonts/PirateHat.mesh", 12221595},
            {"rbxasset://fonts/PoliceCap.mesh", 12221603},
            {"rbxasset://fonts/rocketlauncher.mesh", 12221651},
            {"rbxasset://fonts/slingshot.mesh", 12221682},
            {"rbxasset://fonts/sombrero.mesh", 12221705},
            {"rbxasset://fonts/sword.mesh", 12221720},
            {"rbxasset://fonts/timebomb.mesh", 12221733},
            {"rbxasset://fonts/tophat.mesh", 12221750},
            {"rbxasset://fonts/tree.mesh", 12221787},
            {"rbxasset://fonts/trowel.mesh", 12221793},
            {"rbxasset://fonts/VikingHelmet.mesh", 12221815}
        };

        public static long Check(string assetId)
        {
            if (Database.ContainsKey(assetId))
                return Database[assetId];
            else
                return -1;
        }
    }
}
