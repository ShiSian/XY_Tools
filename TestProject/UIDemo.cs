﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TestProject
{
    [Transaction(TransactionMode.Manual)]
    class UIDemo : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            throw new NotImplementedException();
        }

        public Result OnStartup(UIControlledApplication application)
        {
			//【01】创建一个RibbonTab
			application.CreateRibbonTab("XY工具集");
			//【02】在刚才的RibbonTab中创建RibbonPanel
			RibbonPanel rp = application.CreateRibbonPanel("XY工具集", "插件管理器");
			//【03】指定程序集的名称以及使用的类名
			string assemblyPath = Assembly.GetExecutingAssembly().Location;
			//获取程序集的路径（相对路径）
			string classNameHelloRevit = "TestProject.TabManager"; //namespaceName.className
			//【04-01】创建pushbutton
			PushButtonData pbd = new PushButtonData("InnerNameRevit", "Hello,Revit", assemblyPath, classNameHelloRevit);
			//new PushButtonData("在程序内部的名称，必须唯一", "在按钮上显示的名称", 程序集dll的路径, 命名空间以及类名)
			//【04-02】将pushbuttom添加到RibbonPanel中
			PushButton pushButton = rp.AddItem(pbd) as PushButton;
			//【04-03】给按钮设置一个图片(大图标一般是32px，小图标一般是16px,格式可以是ico或者png）
			//设置图片路径（右击项目名称>>添加>>文件夹>>新建文件夹并将图片拖动到文件夹中>>右击图片名称>>属性>>生成操作>>Resource
			pushButton.LargeImage = new BitmapImage(new Uri("pack://application:,,,/TestProject;component/pic/TabManager.png", UriKind.Absolute));//UIDemo指的是命名空间名
			//【04-04】给按钮设置一个默认提示信息
			pushButton.ToolTip = "HelloRevit";
			//【06】返回程序执行结果
			return Result.Succeeded;
		}
    }
}
