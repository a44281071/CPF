using CPF.Animation;
using CPF;
using CPF.Controls;
using CPF.Documents;
using CPF.Drawing;
using CPF.Effects;
using CPF.Input;
using CPF.Styling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPF.Shapes;

namespace HostDemo.Views;
 
public class ShellView : Window
{
    protected override void InitializeComponent()
    {
        Icon = "res://ConsoleApp1.icon.png";
        ViewFill color = "#242424";
        ViewFill hoverColor = "255,255,255,40";
        Title = "标题123test";
        CanResize = true;
        Background = null;
        MinWidth = 150;
        MinHeight = 50;
        //AllowDrop = true;
        Width = 810.4f;
        Height = 575.2f;
        DragThickness = 10;

        //窗体阴影
        var frame = Children.Add(new Border
        {
            Width = "100%",
            Height = "100%",
            Background = "255,255,255",
            BorderType = BorderType.BorderStroke,
            BorderStroke = new Stroke(0),//ShadowHorizontal = 10,
                                         //ShadowVertical = 10,
            Bindings =
                {
                    {
                        nameof(Border.ShadowBlur),
                        nameof(Window.WindowState),
                        this,
                        BindingMode.OneWay,
                        (WindowState a) => a == WindowState.Maximized||a== WindowState.FullScreen ? 0 : 20
                    }
                }
        });
        //用来裁剪内容，不然内容超出阴影
        var clip = new Decorator
        {
            Width = "100%",
            Height = "100%",
            ClipToBounds = true,//Background = "#fff"
        };
        frame.Child = clip;
        var grid = (Grid)(clip.Child = new Grid
        {
            Width = "100%",
            Height = "100%",
            ColumnDefinitions =
                {
                    new ColumnDefinition()
                },
            RowDefinitions =
                {
                    new RowDefinition
                    {
                        Height = 30
                    },
                    new RowDefinition
                    {

                    }
                },
        });
        //标题栏和按钮
        grid.Children.Add(
        new Panel
        {
            Name = "caption",//Background = "#1E9FFF",
            Width = "100%",
            Height = "100%",
            Commands =
            {
                    {
                        nameof(Window.MouseDown),
                        nameof(Window.DragMove),
                        this
                    }
            },
            Children =
            {
                    new TextBlock
                    {
                        MarginLeft=10,
                        Bindings=
                        {
                            {
                                nameof(TextBlock.Text),
                                nameof(Window.Title),
                                this
                            }
                        },
                        Foreground="#fff"
                    },
                    new StackPanel
                    {
                        MarginRight=0,
                        Height = "100%",
                        Orientation= Orientation.Horizontal,
                        Children =
                        {
                            new Panel
                            {
                                ToolTip="最小化",
                                Name="min",
                                Width = 30,
                                Height = "100%",
                                Children =
                                {
                                    new Line
                                    {
                                        MarginLeft=8,
                                        MarginTop=5,
                                        StartPoint = new Point(1, 13),
                                        EndPoint = new Point(14, 13),
                                        StrokeStyle = "2",
                                        IsAntiAlias=true,
                                        StrokeFill=color
                                    },
                                },
                                Commands =
                                {
                                    {
                                        nameof(Button.MouseDown),
                                        (s,e)=>
                                        {
                                            (e as MouseButtonEventArgs).Handled = true;
                                            this.WindowState = WindowState.Minimized;
                                        }
                                    }
                                },
                                Triggers=
                                {
                                    new Trigger(nameof(Panel.IsMouseOver), Relation.Me)
                                    {
                                        Setters =
                                        {
                                            {
                                                nameof(Panel.Background),
                                                hoverColor
                                            }
                                        }
                                    }
                                },
                            },
                            new Panel
                            {
                                ToolTip="最大化",
                                Name="max",
                                Width = 30,
                                Height = "100%",
                                Children=
                                {
                                    new Rectangle
                                    {
                                        Width=14,
                                        Height=12,
                                        StrokeStyle="2",
                                        StrokeFill = color
                                    }
                                },
                                Commands =
                                {
                                    {
                                        nameof(Button.MouseDown),
                                        (s,e)=>
                                        {
                                            (e as MouseButtonEventArgs).Handled = true;
                                            this.WindowState= WindowState.Maximized;
                                        }
                                    }
                                },
                                Triggers=
                                {
                                    new Trigger(nameof(Panel.IsMouseOver), Relation.Me)
                                    {
                                        Setters =
                                        {
                                            {
                                                nameof(Panel.Background),
                                                hoverColor
                                            }
                                        }
                                    }
                                },
                                Bindings =
                                {
                                    {
                                        nameof(Border.Visibility),
                                        nameof(Window.WindowState),
                                        this,
                                        BindingMode.OneWay,
                                        a => (WindowState)a == WindowState.Maximized||(WindowState)a == WindowState.FullScreen ? Visibility.Collapsed : Visibility.Visible
                                    }
                                },
                            },
                            new Panel
                            {
                                ToolTip="向下还原",
                                Name="nor",
                                Width = 30,
                                Height = "100%",
                                Children=
                                {
                                    new Rectangle
                                    {
                                        MarginTop=15,
                                        MarginLeft=8,
                                        Width=11,
                                        Height=8,
                                        StrokeStyle="1.5",
                                        StrokeFill = color
                                    },
                                    new Polyline
                                    {
                                        MarginTop=11,
                                        MarginLeft=12,
                                        Points=
                                        {
                                            new Point(0,3),
                                            new Point(0,0),
                                            new Point(9,0),
                                            new Point(9,7),
                                            new Point(6,7)
                                        },
                                        StrokeFill = color,
                                        StrokeStyle="2"
                                    }
                                },
                                Commands =
                                {
                                    {
                                        nameof(Button.MouseDown),
                                        (s, e) =>
                                        {
                                            (e as MouseButtonEventArgs).Handled = true;
                                            this.WindowState = WindowState.Normal;
                                        }
                                    }
                                },
                                Bindings =
                                {
                                    {
                                        nameof(Border.Visibility),
                                        nameof(Window.WindowState),
                                        this,
                                        BindingMode.OneWay,
                                        (WindowState a) => a == WindowState.Normal ? Visibility.Collapsed : Visibility.Visible
                                    }
                                },
                                Triggers=
                                {
                                    new Trigger(nameof(Panel.IsMouseOver), Relation.Me)
                                    {
                                        Setters =
                                        {
                                            {
                                                nameof(Panel.Background),
                                                hoverColor
                                            }
                                        }
                                    }
                                },
                            },
                            new Panel
                            {
                                Name="close",
                                ToolTip="关闭",
                                Width = 30,
                                Height = "100%",
                                Children =
                                {
                                    new Line
                                    {
                                        MarginTop=8,
                                        MarginLeft=8,
                                        StartPoint = new Point(1, 1),
                                        EndPoint = new Point(14, 13),
                                        StrokeStyle = "2",
                                        IsAntiAlias=true,
                                        StrokeFill=color
                                    },
                                    new Line
                                    {
                                        MarginTop=8,
                                        MarginLeft=8,
                                        StartPoint = new Point(14, 1),
                                        EndPoint = new Point(1, 13),
                                        StrokeStyle = "2",
                                        IsAntiAlias=true,
                                        StrokeFill=color
                                    }
                                },
                                Commands =
                                {
                                    {
                                        nameof(Button.MouseDown),
                                        (s, e) =>
                                        {
                                             (e as MouseButtonEventArgs).Handled = true;
                                            this.Close();
                                        }
                                    }
                                },
                                Triggers=
                                {
                                    new Trigger(nameof(Panel.IsMouseOver), Relation.Me)
                                    {
                                        Setters =
                                        {
                                            {
                                                nameof(Panel.Background),
                                                hoverColor
                                            }
                                        }
                                    }
                                },
                            }
                        }
                    }
            }
        });
      
        grid.Children.Add(new TabControl
        {
            Width = "100%",
            Height = "100%",//Background = "10,255,255,255",
            SwitchAction = (oldItem, newItem) =>
            {
                if (oldItem != null && oldItem.ContentElement != null)
                {
                    oldItem.ContentElement.TransitionValue(nameof(UIElement.MarginLeft), (FloatField)"-100%", TimeSpan.FromSeconds(0.2), new PowerEase(), AnimateMode.EaseOut, () =>
                    {
                        oldItem.ContentElement.Visibility = Visibility.Collapsed;
                    });
                }
                if (newItem != null && newItem.ContentElement != null)
                {
                    newItem.ContentElement.Visibility = Visibility.Visible;
                    newItem.ContentElement.MarginLeft = "100%";
                    newItem.ContentElement.TransitionValue(nameof(UIElement.MarginLeft), (FloatField)"0%", TimeSpan.FromSeconds(0.2), new PowerEase(), AnimateMode.EaseOut);
                }
            },
            Items =
                {
                    new TabItem
                    {
                        Header="基础控件",
                        Content=new StackPanel
                        {
                            Width="100%",
                            Height="100%",//Background=Color.FromArgb(100,0,0,0),
                        //Background="linear-gradient(0 0,300 300,#fff,#000,#faa)",
                        Children=
                            {
                                new StackPanel
                                {
                                    Orientation= Orientation.Horizontal,
                                    Children=
                                    {
                                        new Button
                                        {
                                            Content = "打开文件对话框",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    async (s,e)=>
                                                    {
                                                        var f=new OpenFileDialog
                                                        {
                                                            Title="打开文件",
                                                            AllowMultiple=true
                                                        };
                                                        f.Filters.Add(new FileDialogFilter
                                                        {
                                                            Name="*",
                                                            Extensions="bmp,jpeg,png,jpg"
                                                        });
                                                        var sf=await f.ShowAsync(this);
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content = "选择目录对话框",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        ThreadPool.QueueUserWorkItem(async a=>
                                                        {
                                                            var sf=await new OpenFolderDialog
                                                            {
                                                                Title="标题"
                                                            }
                                                            .ShowAsync(this);
                                                        },null);
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content = "保存文件对话框",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    async (s,e)=>
                                                    {
                                                        var f=new SaveFileDialog
                                                        {
                                                            Title="保存文件",
                                                            Filters=
                                                            {
                                                                new FileDialogFilter
                                                                {
                                                                    Extensions="dll",
                                                                    Name="dll文件"
                                                                }
                                                            }
                                                        };
                                                        var sf= await f.ShowAsync(this);
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content = "模态窗体",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    async (s,e)=>
                                                    {
                                                        var f=new Window();
                                                        f.Background="#000";
                                                        f.Width=300;
                                                        f.Height=300;
                                                        f.CanResize=true;
                                                        f.Commands.Add(nameof(f.DoubleClick),(ss,ee)=>f.Close());
                                                        await f.ShowDialog(this);
                                                        //MessageBox.Show("dfs");
                                                        System.Diagnostics.Debug.WriteLine("test");
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content = "切换样式2",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        var b=s as Button;
                                                        if (b.Content.ToString()=="切换样式2")
                                                        {
                                                            LoadStyleFile("res://ConsoleApp1.Stylesheet2.css");
                                                            b.Content="切换样式1";
                                                        }
                                                        else
                                                        {
                                                            LoadStyleFile("res://ConsoleApp1.Stylesheet1.css");
                                                            b.Content="切换样式2";
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="全屏",
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        this.WindowState=WindowState== WindowState.FullScreen?WindowState.Normal: WindowState.FullScreen;
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="最前端",
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        this.TopMost = !this.TopMost;
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="ShowInBar",
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        this.ShowInTaskbar = !this.ShowInTaskbar;
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="移动窗体",
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        this.Position=new PixelPoint(-100,0);
                                                    }
                                                }
                                            }
                                        },
                                    }
                                },
                                new CheckBox
                                {
                                    Content="TextBlock测试🌐",
                                    MarginTop=2
                                },
                                new CheckBox
                                {
                                    Content="选择2",
                                    MarginTop=2,
                                    IsThreeState=true
                                },
                                new RadioButton
                                {
                                    Content=new Button
                                    {
                                        Content="单选1"
                                    },
                                    Background="#fff",
                                    MarginTop=2,
                                    GroupName="分组"
                                },
                                new RadioButton
                                {
                                    Content="单选2",
                                    MarginTop=2,
                                    GroupName="分组"
                                },
                                new ComboBox
                                {
                                    ItemTemplate=new ListBoxItem
                                    {
                                        FontSize=24,
                                        Width="100%",
                                        ContentTemplate=new ContentTemplate
                                        {
                                            Width="auto",
                                            MarginLeft=0
                                        }
                                    },
                                    Width=100,
                                    Height=25,
                                    Items =
                                    {
                                        new ListBoxItem
                                        {
                                            Content="test"
                                        },
                                        new ListBoxItem
                                        {
                                            Content="test2"
                                        },
                                    }
                                },
                                new TextBox
                                {
                                    Classes=
                                    {
                                        "Single"
                                    },
                                    PasswordChar='*',
                                    Width=100,
                                    Height=25,
                                    Bindings=
                                    {
                                        {
                                            nameof(TextBlock.Text),
                                            nameof(ShellViewModel.DisplayName),
                                            null,
                                            BindingMode.OneWayToSource,
                                            null,
                                            a=>
                                            {
                                                var tb = Binding.Current.Owner as TextBox;
                                                return DrawingFactory.Default.MeasureString(a.ToString(), new Font(tb.FontFamily, tb.FontSize, tb.FontStyle)).ToString();
                                            }
                                        }
                                    }
                                },
                            }
                        }
                    },
                    new TabItem
                    {
                        Header="动画",
                        Content=new Panel
                        {
                            Width="100%",
                            Height="100%",
                            Children=
                            {
                                new Button
                                {
                                    RenderTransform=new RotateTransform(10),
                                    Content = "按住鼠标播放动画",
                                    Width=100,
                                    Height=30,
                                    MarginTop=39,
                                    MarginLeft=0,
                                    Triggers=
                                    {
                                        new Trigger
                                        {
                                            Property=nameof(Button.IsMouseCaptured),
                                            Animation= new Storyboard
                                            {
                                                Timelines =
                                                {
                                                    new Timeline(.5f)
                                                    {
                                                        //定义一个时间线，从上个时间点到这个时间点。0到1，相对整个动画的时间。现在定义的是前一半的时间
                                    KeyFrames =
                                                        {
                                                            new KeyFrame<FloatField>
                                                            {
                                                                Property = nameof(UIElement.MarginLeft),//属性名
                                            Value = 400,//动画目标值
                                            //Ease = new PowerEase(),//缓动方式
                                            AnimateMode = AnimateMode.Linear//线性或者缓动
                                                            },//new KeyFrame<FloatField> {
                                        //    Property = nameof(UIElement.MarginTop),//属性名
                                        //    Value = 200,//动画目标值
                                        //}
                                                        }
                                                    },
                                                    new Timeline(1)
                                                    {
                                                        //从上一个时间点0.5到1，就是后一半的时间
                                    KeyFrames =
                                                        {
                                                            new KeyFrame<GeneralTransform>
                                                            {
                                                                Property = nameof(UIElement.RenderTransform),
                                                                Value = new GeneralTransform()
                                                                {
                                                                    Angle=720,
                                                                    ScaleX=2,
                                                                    ScaleY=2
                                                                },
                                                                Ease = new BackEase(),
                                                                AnimateMode = AnimateMode.Linear
                                                            }
                                                        }
                                                    },
                                                }
                                            },
                                            AnimationDuration = TimeSpan.FromSeconds(1)
                                        }
                                    },
                                },
                                new TextBlock
                                {
                                    MarginTop=111,
                                    MarginLeft=0,
                                    Text="鼠标移入变色CSS定义",
                                    Classes=
                                    {
                                        "testAnimation1"
                                    }
                                },
                                new Picture
                                {
                                    MarginTop=111.3f,
                                    Source="https://dss0.bdstatic.com/5aV1bjqh_Q23odCf/static/superman/img/logo_top-e3b63a0b1b.png",
                                    Triggers=
                                    {
                                        new Trigger(nameof(IsMouseOver), Relation.Me)
                                        {
                                            Animation=new Storyboard
                                            {
                                                Timelines =
                                                {
                                                    new Timeline(1)
                                                    {
                                                        KeyFrames =
                                                        {
                                                            new KeyFrame<GeneralTransform>
                                                            {
                                                                Property = nameof(UIElement.RenderTransform),
                                                                Value = new GeneralTransform()
                                                                {
                                                                    ScaleX=1.5f,
                                                                    ScaleY=1.5f
                                                                },
                                                                Ease = new BackEase(),
                                                                AnimateMode = AnimateMode.EaseIn
                                                            }
                                                        }
                                                    }
                                                }
                                            },
                                            AnimationDuration = TimeSpan.FromSeconds(.5)
                                        }
                                    }
                                },
                                new ScrollBar
                                {
                                    Name="animationTransition",
                                    Orientation= Orientation.Horizontal,
                                    Maximum=1000,
                                    Width=500
                                },
                                new Button
                                {
                                    MarginLeft=5,
                                    MarginTop=180,
                                    Content="动态过渡到某个值",
                                    Commands=
                                    {
                                        {
                                            nameof(MouseDown),
                                            (s,e)=>
                                            {
                                                this.Find<ScrollBar>().FirstOrDefault(a=>a.Name== "animationTransition").TransitionValue(a=>a.Value,new Random().Next(0,1000),TimeSpan.FromSeconds(0.3));
                                            }
                                        }
                                    }
                                },
                            }
                        }
                    },  
                }
        }, 0, 1);
      
    }
}
