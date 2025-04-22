# CPF - Forward!



## 改进介绍

基于较新技术，模仿现代化框架，从各方面向他们接近。

从程序入口、约定、配置、Fluent 代码，各种方向，尽量的简化和现代代码写法。



#### CPF 介绍

C#跨平台UI框架

提供NETStandard2.0和net4的库，通过Netcore可以跨平台，支持Windows、Mac、Linux，Net4的可以支持XP。各个平台运行效果一致，不依赖系统控件。<br/>
支持窗体，控件任意透明，支持异形窗体，支持SVG图标显示。<br/>
支持动画，数据绑定，Mvvm模式，CSS等，简化依赖属性，数据绑定的写法，提供数据上下文和命令上下文来绑定，直接用CSS和C#代码描述。<br/>
提供设计器生成C#代码和开发者工具查看和调试元素<br/>
和WPF一样的理念，任何控件都可以任意设计模板来实现各种效果<br/>
除了使用平台相关API之外，基本可以实现一次编写，到处运行<br/>
全面支持国产化，支持国产Linux + 龙芯、飞腾、兆芯、海光等CPU平台

 **gitee** :https://gitee.com/csharpui/CPF <br/>
 **github** :https://github.com/wsxhm/CPF

![输入图片说明](Other/2image.png)

![输入图片说明](Other/1image.png)

![输入图片说明](Other/image.png)

![输入图片说明](Other/yunchaobi.gif)

 **Apache License 2.0** 

#### 软件架构

软件架构说明

CPF为主要框架，CPF.Skia为用skia做图形适配，CPF.Windows、CPF.Linux、CPF.Mac、CPF.Android为各个平台的适配器

#### 使用说明

直接克隆/下载就可以编译，直接启动ConsoleApp1看运行效果

CPF使用文档 http://cpf.cskin.net/Course/#/

#### 扩展库

https://gitee.com/csharpui/cpf.cef  使用CPF对cef的封装，跨平台浏览器控件

https://gitee.com/csharpui/cpf.vlc  使用CPF对vlc的封装，跨平台视频播放控件

#### 关于设计器

设计器不开源，设计器是需要另外收费的，免费模式可以刷新和预览，不能拖拽和审查元素，可以免费试用VIP一个月
更多详细内容可以到 http://cpf.cskin.net/ 

![输入图片说明](Other/3image.png)
![输入图片说明](Other/4image.png)

### Nugets

| Packages        | Version                                                                                                                           |
| --------------- | --------------------------------------------------------------------------------------------------------------------------------- |
| Xhm.CPF         | [![NuGet Status](https://img.shields.io/nuget/v/Xhm.CPF.svg?style=flat)](https://www.nuget.org/packages/Xhm.CPF/)                 |
| Xhm.CPF.Windows | [![NuGet Status](https://img.shields.io/nuget/v/Xhm.CPF.Windows.svg?style=flat)](https://www.nuget.org/packages/Xhm.CPF.Windows/) |
| Xhm.CPF.Skia    | [![NuGet Status](https://img.shields.io/nuget/v/Xhm.CPF.Skia.svg?style=flat)](https://www.nuget.org/packages/Xhm.CPF.Skia/)       |
| Xhm.CPF.Linux   | [![NuGet Status](https://img.shields.io/nuget/v/Xhm.CPF.Linux.svg?style=flat)](https://www.nuget.org/packages/Xhm.CPF.Linux/)     |
| Xhm.CPF.Mac     | [![NuGet Status](https://img.shields.io/nuget/v/Xhm.CPF.Mac.svg?style=flat)](https://www.nuget.org/packages/Xhm.CPF.Mac/)         |

#### 参与贡献

打赏/捐赠

微信/支付宝

<img src="https://gitee.com/csharpui/CPF/raw/master/Other/weixin.png" title="微信">
<img src="https://gitee.com/csharpui/CPF/raw/master/Other/zhifubao.png" title="支付宝">

1. Fork 本仓库
2. 新建 Feat_xxx 分支
3. 提交代码
4. 新建 Pull Request

QQ群：894952004
