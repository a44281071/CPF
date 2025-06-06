﻿using CPF;
using CPF.Animation;
using CPF.Charts;
using CPF.Controls;
using CPF.Drawing;
using CPF.Shapes;
using CPF.Styling;
using CPF.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    [CPF.Design.DesignerLoadStyle("res://ConsoleApp1/Stylesheet1.css")]//用于设计的时候加载样式
    public class ListBoxItem1 : ListBoxItem
    {
        //public (string title, string host) vdata;
        public vd vdata;
        public string SvgSource
        {
            get
            {
                return (string)GetValue();
            }
            set
            {
                SetValue(value);
            }
        }
        public bool HostState
        {
            set
            {
                if (value)
                {
                    SvgSource = "<svg t=\"1635655087588\" class=\"icon\" viewBox=\"0 0 1114 1024\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\" p-id=\"2067\" width=\"30\" height=\"30\"><path d=\"M668.16 382.72v291.84l103.68 52.48 52.48-32-97.28-44.8V418.56l107.52-48.64 197.12 93.44v-60.16l-197.12-94.72-166.4 74.24z\" p-id=\"2068\" fill=\"#1296db\"></path><path d=\"M761.6 510.72v-65.28l72.96-32 256 120.32v199.68L921.6 824.32l-34.56-38.4 147.2-89.6V565.76L834.56 473.6l-72.96 37.12z\" p-id=\"2069\" fill=\"#1296db\"></path><path d=\"M629.76 494.08l-56.32 33.28v204.8l193.28 92.16 226.56-136.96v-107.52l-51.2-20.48v104.96l-175.36 101.12-136.96-70.4V494.08z\" p-id=\"2070\" fill=\"#1296db\"></path><path d=\"M528.64 824.32H189.44c-96-19.2-167.68-102.4-167.68-203.52 0-108.8 85.76-199.68 194.56-206.08 2.56-163.84 136.96-295.68 300.8-295.68 130.56 0 221.44 46.08 280.32 157.44l-66.56 29.44c-43.52-88.32-112.64-120.32-213.76-120.32-129.28 0-234.24 104.96-234.24 234.24 0 8.96 0 16.64 1.28 25.6l5.12 40.96-40.96-5.12c-5.12 0-11.52-1.28-16.64-1.28C153.6 480 89.6 542.72 89.6 620.8c0 75.52 60.16 136.96 135.68 140.8h304.64v62.72h-1.28z\" p-id=\"2071\" fill=\"#1296db\"></path><path d=\"M528.64 824.32H189.44c-96-19.2-167.68-102.4-167.68-203.52 0-108.8 85.76-199.68 194.56-206.08 66.56 5.12 71.68 71.68 71.68 71.68l-40.96-5.12c-5.12 0-11.52-1.28-16.64-1.28-78.08 0-142.08 62.72-142.08 140.8 0 75.52 60.16 136.96 135.68 140.8h304.64v62.72z\" p-id=\"2072\" fill=\"#1296db\"></path></svg>";
                }
                else
                {
                    SvgSource = "<svg t=\"1635655087588\" class=\"icon\" viewBox=\"0 0 1114 1024\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\" p-id=\"2067\" width=\"30\" height=\"30\"><path d=\"M668.16 382.72v291.84l103.68 52.48 52.48-32-97.28-44.8V418.56l107.52-48.64 197.12 93.44v-60.16l-197.12-94.72-166.4 74.24z\" p-id=\"2068\" fill=\"#d4237a\"></path><path d=\"M761.6 510.72v-65.28l72.96-32 256 120.32v199.68L921.6 824.32l-34.56-38.4 147.2-89.6V565.76L834.56 473.6l-72.96 37.12z\" p-id=\"2069\" fill=\"#d4237a\"></path><path d=\"M629.76 494.08l-56.32 33.28v204.8l193.28 92.16 226.56-136.96v-107.52l-51.2-20.48v104.96l-175.36 101.12-136.96-70.4V494.08z\" p-id=\"2070\" fill=\"#d4237a\"></path><path d=\"M528.64 824.32H189.44c-96-19.2-167.68-102.4-167.68-203.52 0-108.8 85.76-199.68 194.56-206.08 2.56-163.84 136.96-295.68 300.8-295.68 130.56 0 221.44 46.08 280.32 157.44l-66.56 29.44c-43.52-88.32-112.64-120.32-213.76-120.32-129.28 0-234.24 104.96-234.24 234.24 0 8.96 0 16.64 1.28 25.6l5.12 40.96-40.96-5.12c-5.12 0-11.52-1.28-16.64-1.28C153.6 480 89.6 542.72 89.6 620.8c0 75.52 60.16 136.96 135.68 140.8h304.64v62.72h-1.28z\" p-id=\"2071\" fill=\"#1296db\"></path><path d=\"M528.64 824.32H189.44c-96-19.2-167.68-102.4-167.68-203.52 0-108.8 85.76-199.68 194.56-206.08 66.56 5.12 71.68 71.68 71.68 71.68l-40.96-5.12c-5.12 0-11.52-1.28-16.64-1.28-78.08 0-142.08 62.72-142.08 140.8 0 75.52 60.16 136.96 135.68 140.8h304.64v62.72z\" p-id=\"2072\" fill=\"#1296db\"></path></svg>";
                }//d4237a
            }
        }
        //模板定义
        protected override void InitializeComponent()
        {
            //模板定义
            //CornerRadius="15";
            //BorderFill = "#000";
            //BorderStroke = "1";
            if (DesignMode)
            {
                Width = 200;
            }
            else
            {
                Width = "100%";
            }
            Height = 40;
            Background = "#fff";
            Children.Add(new SVG
            {
                IsAntiAlias = true,
                Size = "22,22",
                Stretch = Stretch.Uniform,
                Width = 30,
                Height = 30,
                MarginLeft = 5,
                Bindings = {
                    { nameof(SVG.Source),nameof(SvgSource),this}
                }
            });
            Children.Add(new TextBlock
            {
                Text = vdata.title,
                MarginLeft = 40,
                MarginTop = 5,
            });
            Children.Add(new TextBlock
            {
                Text = vdata.host,
                MarginLeft = 40,
                MarginTop = 20,
                Foreground = "#666",
            });
            Triggers.Add(new Trigger
            {
                Property = nameof(IsMouseOver),
                PropertyConditions = a => (bool)a && !IsSelected,
                Setters =
                {
                    {
                        nameof(Background),
                        "229,243,251"
                    }
                }
            });
            Triggers.Add(new Trigger
            {
                Property = nameof(IsSelected),
                PropertyConditions = a => (bool)a,
                Setters =
                {
                    {
                        nameof(Background),
                        "203,233,246"
                    }
                }
            });
        }
    }

    public struct vd
    {
        public string title { set; get; }
        public string host { set; get; }
    }
}
