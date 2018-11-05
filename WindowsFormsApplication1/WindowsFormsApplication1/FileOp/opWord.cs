using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Word;
using MSWord = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;

namespace WindowsFormsApplication1.FileOp
{
    public class opWord
    {
        private _Application wordApp = null;
        private _Document wordDoc = null;

        public _Application Applicaton
        {
            get { return wordApp; }
            set { wordApp = value; }
        }

        public _Document WordDoc
        {
            get { return wordDoc; }
            set { wordDoc = value; }
        }

        public void ACDocs()
        {
            string currTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string filePath = Environment.CurrentDirectory + "\\交流充电桩测试报表模块V102.doc";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            CreateNewDocument(filePath);
            SetPage();
            FillContent();
            SaveDocument(filePath);
        }

        /// <summary>
        /// 通过模板创建新文件
        /// </summary>
        /// <param name="filePath"></param>
        public void CreateNewDocument(string filePath)
        {
            //killWnWordProcess();
            wordApp = new ApplicationClass();
            wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            wordApp.Visible = true;//可以改为false
            object missing = System.Reflection.Missing.Value;
            //由于使用的是COM库，因此有许多变量需要用Missing.Value代替
            Object Nothing = Missing.Value;

            object templateName = filePath;

            wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

            //wordDoc = wordApp.Documents.Open(ref templateName, ref missing,
            //    ref missing, ref missing, ref missing, ref missing, ref missing,
            //    ref missing, ref missing, ref missing, ref missing, ref missing,
            //    ref missing, ref missing, ref missing, ref missing);
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveDocument(string filePath)
        {
            object fileName = filePath;
            object format = WdSaveFormat.wdFormatDocument; //保存格式
            object missing = System.Reflection.Missing.Value;
            wordDoc.SaveAs(ref fileName, ref format, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing);
            //关闭wordDoc,wordApp对象
            object saveChanges = WdSaveOptions.wdSaveChanges;
            object originalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object routeDocument = false;
            wordDoc.Close(ref saveChanges, ref originalFormat, ref routeDocument);
            wordApp.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
        }
        /// <summary>
        /// 打开文档
        /// </summary>
        /// <param name="filePath"></param>
        public void OpenDocument(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }
            //我还要打开这个文档玩玩
            MSWord.Application app = new MSWord.Application();
            MSWord.Document doc = null;
            try
            {

                object unknow = Type.Missing;
                app.Visible = true;
                //string str = Environment.CurrentDirectory + "\\MyWord_Print.doc";
                object file = filePath;
                doc = app.Documents.Open(ref file,
                    ref unknow, ref unknow, ref unknow, ref unknow,
                    ref unknow, ref unknow, ref unknow, ref unknow,
                    ref unknow, ref unknow, ref unknow, ref unknow,
                    ref unknow, ref unknow, ref unknow);
                //string temp = doc.Paragraphs[1].Range.Text.Trim();
                //Console.WriteLine("你他妈输出temp干嘛？");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //wordDoc = doc;
            //wordDoc.Paragraphs.Last.Range.Text += "我真的不打算再写了,就写这么多吧";

            //Console.ReadKey();
        }

        /// <summary>
        /// 页面设置、页眉图片和文字设置，最后跳出页眉设置
        /// </summary>
        /// <param name="filePath"></param>
        public void SetPage()
        {
            //页面设置
            wordDoc.PageSetup.PaperSize = MSWord.WdPaperSize.wdPaperA4;//设置纸张样式为A4纸
            wordDoc.PageSetup.Orientation = MSWord.WdOrientation.wdOrientPortrait;//排列方式为垂直方向
            wordDoc.PageSetup.TopMargin = 57.0f;
            wordDoc.PageSetup.BottomMargin = 57.0f;
            wordDoc.PageSetup.LeftMargin = 57.0f;
            wordDoc.PageSetup.RightMargin = 57.0f;
            wordDoc.PageSetup.HeaderDistance = 30.0f;//页眉位置

            #region 页码设置并添加页码

            //为当前页添加页码
            MSWord.PageNumbers pns = wordApp.Selection.Sections[1].Headers[MSWord.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers;//获取当前页的号码
            pns.NumberStyle = MSWord.WdPageNumberStyle.wdPageNumberStyleNumberInDash;//设置页码的风格，是Dash形还是圆形的
            pns.HeadingLevelForChapter = 0;
            pns.IncludeChapterNumber = false;
            pns.RestartNumberingAtSection = false;
            pns.StartingNumber = 0; //开始页页码？
            object pagenmbetal = MSWord.WdPageNumberAlignment.wdAlignPageNumberCenter;//将号码设置在中间
            object first = true;
            wordApp.Selection.Sections[1].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterEvenPages].PageNumbers.Add(ref pagenmbetal, ref first);

            #endregion
        }
        /// <summary>
        /// 填充内容
        /// </summary>
        /// <param name="filePath"></param>
        public void FillContent()
        {
            string strContent;
            //由于使用的是COM库，因此有许多变量需要用Missing.Value代替
            Object Nothing = Missing.Value;
            object unite = MSWord.WdUnits.wdStory;

            wordApp.Selection.ParagraphFormat.LineSpacing = 16f;//设置文档的行间距
            wordApp.Selection.ParagraphFormat.FirstLineIndent = 30;//首行缩进的长度

            wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            wordDoc.Paragraphs.Last.Range.Font.Size = 36;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车            

            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Size = 26;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
            strContent = "交流充电桩检验报告\n";
            wordDoc.Paragraphs.Last.Range.Text = strContent;


            wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)10.5;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车 

            wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)10.5;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
            strContent = "NO:\n";
            wordDoc.Paragraphs.Last.Range.Text = strContent;

            wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)10.5;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车 
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车 
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车 
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车
            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车 

            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordApp.Selection.ParagraphFormat.FirstLineIndent = wordApp.CentimetersToPoints(float.Parse("3.5"));//首行缩进
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)14;//四号字体
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
            strContent = "产品名称：\n产品型号：\n委托单位：\n制 造 商：\n\n\n\n\n\n\n\n";
            wordDoc.Paragraphs.Last.Range.Text = strContent;

            wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordApp.Selection.ParagraphFormat.FirstLineIndent = 0;//首行缩进的长度
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)14;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
            strContent = "检验项目总表\n";
            wordDoc.Paragraphs.Last.Range.Text = strContent;

            //插入表格
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordApp.Selection.ParagraphFormat.FirstLineIndent = 0;//首行缩进的长度
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)10.5;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";

            //wordDoc.Content.InsertAfter("\n");//这一句与下一句的顺序不能颠倒，原因还没搞透
            wordApp.Selection.EndKey(ref unite, ref Nothing); //将光标移动到文档末尾
            wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;
            //设置表格的行数和列数
            int tableRow = 1;
            int tableColumn = 3;
            //定义一个Word中的表格对象
            MSWord.Table table = wordDoc.Tables.Add(wordApp.Selection.Range, tableRow, tableColumn, ref Nothing, ref Nothing);
            //默认创建的表格没有边框，这里修改其属性，使得创建的表格带有边框 
            table.Borders.Enable = 1;//这个值可以设置得很大，例如5、13等等

            table.Cell(1, 1).Range.Text = "序号";//填充每列的标题
            table.Cell(1, 2).Range.Text = "检测项目";//填充每列的标题
            table.Cell(1, 3).Range.Text = "判定结果";//填充每列的标题

            //添加行
            table.Rows.Add(ref Nothing);
            table.Cell(2, 1).Range.Text = "1";
            table.Cell(2, 2).Range.Text = "一般检查";
            table.Rows.Add(ref Nothing);
            table.Cell(3, 1).Range.Text = "2";
            table.Cell(3, 2).Range.Text = "充电模式和连接方式检查";
            table.Rows.Add(ref Nothing);
            table.Cell(4, 1).Range.Text = "3";
            table.Cell(4, 2).Range.Text = "绝缘电阻试验";
            table.Rows.Add(ref Nothing);
            table.Cell(5, 1).Range.Text = "4";
            table.Cell(5, 2).Range.Text = "介电强度试验";
            table.Rows.Add(ref Nothing);
            table.Cell(6, 1).Range.Text = "5";
            table.Cell(6, 2).Range.Text = "接地测试";
            table.Rows.Add(ref Nothing);
            table.Cell(7, 1).Range.Text = "6";
            table.Cell(7, 2).Range.Text = "过流保护功能试验";
            table.Rows.Add(ref Nothing);
            table.Cell(8, 1).Range.Text = "7";
            table.Cell(8, 2).Range.Text = "剩余电流保护试验";
            table.Rows.Add(ref Nothing);
            table.Cell(9, 1).Range.Text = "8";
            table.Cell(9, 2).Range.Text = "连接异常试验";
            table.Rows.Add(ref Nothing);
            table.Cell(10, 1).Range.Text = "9";
            table.Cell(10, 2).Range.Text = "显示功能";
            table.Rows.Add(ref Nothing);
            table.Cell(11, 1).Range.Text = "10";
            table.Cell(11, 2).Range.Text = "输入功能";
            table.Rows.Add(ref Nothing);
            table.Cell(12, 1).Range.Text = "11";
            table.Cell(12, 2).Range.Text = "充电功能";
            table.Rows.Add(ref Nothing);
            table.Cell(13, 1).Range.Text = "12";
            table.Cell(13, 2).Range.Text = "与监控管理系统通信功能";
            table.Rows.Add(ref Nothing);
            table.Cell(14, 1).Range.Text = "13";
            table.Cell(14, 2).Range.Text = "急停功能试验";
            table.Rows.Add(ref Nothing);
            table.Cell(15, 1).Range.Text = "14";
            table.Cell(15, 2).Range.Text = "开门保护试验";
            table.Rows.Add(ref Nothing);
            table.Cell(16, 1).Range.Text = "15";
            table.Cell(16, 2).Range.Text = "工作误差测试";
            table.Rows.Add(ref Nothing);
            table.Cell(17, 1).Range.Text = "16";
            table.Cell(17, 2).Range.Text = "示值误差、付费误差测试";
            table.Rows.Add(ref Nothing);
            table.Cell(18, 1).Range.Text = "17";
            table.Cell(18, 2).Range.Text = "时钟示值误差测定";

            //设置table样式
            table.Rows.HeightRule = MSWord.WdRowHeightRule.wdRowHeightAtLeast;//高度规则是：行高有最低值下限？
            table.Rows.Height = wordApp.CentimetersToPoints(float.Parse("0.8"));// 

            table.Range.Font.Size = 10.5F;
            table.Range.Font.Bold = 0;

            table.Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;//表格文本居中
            table.Range.Cells.VerticalAlignment = MSWord.WdCellVerticalAlignment.wdCellAlignVerticalBottom;//文本垂直贴到底部
            //设置table边框样式
            //table.Borders.OutsideLineStyle = MSWord.WdLineStyle.wdLineStyleDouble;//表格外框是双线
            table.Borders.InsideLineStyle = MSWord.WdLineStyle.wdLineStyleSingle;//表格内框是单线

            //table.Rows[1].Range.Font.Bold = 1;//加粗
            //table.Rows[1].Range.Font.Size = 12F;
            //table.Cell(1, 1).Range.Font.Size = 10.5F;
            //wordApp.Selection.Cells.Height = 30;//所有单元格的高度

            table.Columns[1].Width = (float)53.85;//将第 1列宽度设置为50
            table.Columns[2].Width = (float)227.34;
            table.Columns[3].Width = (float)135.21;

            //中间列居左
            for (int i = 2; i <= 18; i++)
            {
                table.Cell(i, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;
            }
            //表格结束
            wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)10.5;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
            for (int i = 1; i < 14; i++)
            {
                wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车
            }

            //添加各个测试项目
            int index = 1;
            string title = "一般检查";
            string tmethod = "1、检查充电机外壳应平整，无明显凹凸痕、划伤、变形等缺陷；\n2、表面涂镀层应均匀、不应脱落；零部件紧固可靠，无锈蚀、毛刺、裂纹等缺陷和损伤；所有铭牌、标志均安装端正牢固，字迹清晰。";
            string rules = "符合测试要求。";
            string records = "";
            string result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 2;
            title = "充电模式和连接方式检查";
            tmethod = "通过目测检查充电桩是否符合以下要求：\n" +
                "1、供电设备采用的充电模式应符合GB/T 18487.1——2015中5.1规定对应的电动汽车充电模式使用条件；\n" +
                "2、充电机应为连接方式C(含连接方式C下的电缆组件)；\n" +
                "3、交流充电桩应为连接方式A或连接方式B或连接方式C（含连接方式C下的电缆组件）；\n" +
                "4、缆上控制与保护装置应为连接方式B（带有功能盒的电缆组件）。";
            rules = "符合测试要求。";
            records = "充电模式:\n" +
                "连接方式:";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 3;
            title = "绝缘电阻检测";
            tmethod = "1、试验电压：500V。\n" +
                "2、试验部位：\n" +
                "1）交流充电桩输出L对地之间；\n" +
                "2）交流充电桩输出N对地之间。" +
                "";
            rules = "绝缘电阻应不小于10MΩ。";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 4;
            title = "介电强度试验";
            tmethod = "1.	试验电压：AC2kV。\n" +
                "2.	试验时间：1min。\n" +
                "3.	试验部位：\n" +
                "①	交流充电桩输出L对地之间；\n" +
                "②	交流充电桩输出N对地之间。";
            rules = "泄漏电流不应大于10mA。";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 5;
            title = "接地测试";
            tmethod = "通过接地电阻测试仪，测量充电机内任意应该接地的点至总接地之间的电阻值。";
            rules = "接地电阻≤0.1 Ω。";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 6;
            title = "过流保护功能试验";
            tmethod = "将交流充电机连接测试系统，并启动，然后给充电桩加载一个超过过流保护点的负载，检查充电机应能否通过断路器、熔断器或其他组合实现过载保护，并发出告警提示。";
            rules = "符合测试要求";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 7;
            title = "剩余电流保护试验";
            tmethod = "充电运行状态下，使用要求的限流电阻在充电回路中将相线L与外壳或者零线N与外壳短接，检查交流充电桩是否立即切断输入电源。";
            rules = "符合测试要求";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 8;
            title = "连接异常试验";
            tmethod = "交流充电桩在额定负载下进行充电，将充电连接装置连接确认触头断开，检查交流充电桩应立即切断输出,并发出告警提示。";
            rules = "符合测试要求";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 9;
            title = "显示功能";
            tmethod = "对交流充电桩进行启停操作，在充电过程中的各种状态下，检查交流充电桩能显示相关信息，显示字符清晰、完整，没有缺损。";
            rules = "符合测试要求";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 10;
            title = "输入功能";
            tmethod = "手动设置交流充电桩充电参数，检查充电桩应能正确响应。";
            rules = "符合测试要求";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 11;
            title = "充电功能";
            tmethod = "将交流充电机连接测试系统，并启动，然后给充电桩带上负载，测试充电桩输出电压和输出电流是否正常。";
            rules = "符合测试要求";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 12;
            title = "与监控管理系统通信功能";
            tmethod = "交流充电桩在充电运行状态下，人工检查充电桩与监控管理系统通信是否正常，充电数据是否正确无误传至监控管理系统。";
            rules = "符合测试要求";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 13;
            title = "急停功能试验";
            tmethod = "交流充电桩在充电运行状态下，按急停按钮，交流充电桩应立即切断输出电源并发出告警提示。";
            rules = "符合测试要求";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 14;
            title = "开门保护试验";
            tmethod = "对具有维护门且门打开时可造成带电部位露出的充电机，连接试验系统，在充电前，打开充电机门，检查充电机是否无法启动充电。在正常充电过程中，当一体式充电机门打开时，检查充电机是否同时切断动力电源输入和直流输出；当分体式充电机门打开时，检查充电机是否能够断相应终端的动力电源输入和直流输出。";
            rules = "符合测试要求";
            records = "\n" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);

            index = 15;
            title = "工作误差测定";
            tmethod = "标准电能表与被检充电机都在连续工作的情况下,用被检充电机输出电能示值与标准电能表测定电能值确定被检充电机的工作误差。每一个负载功率下,至少记录两次误差测定数据,取其平均值。";
            rules = "符合测试要求";
            records = "如表1所示" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);
            //插入 表1


            index = 16;
            title = "示值误差、付费误差测定";
            tmethod = "将被检充电机与检定装置的电流线路串联,电压线路并联,施加最大负载运行一段时间。停止运行后,计算被检充电机的示值误差和付费误差。";
            rules = "符合测试要求";
            records = "如表2所示" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);
            //插入 表2

            index = 17;
            title = "时钟示值误差测定";
            tmethod = "充电机与标准时钟测试仪同时记录其指示时间,计算充电机时钟示值误差ΔT ,即: ΔT =|T'-T |\n" +
                "式中:\n" +
                "T'———被检充电机的显示时刻,s;\n" +
                "T ———标准时钟测试仪的显示时刻,s。";
            rules = "符合测试要求";
            records = "如表3所示" +
                "";
            result = "";
            FillTestItems(index, title, tmethod, rules, records, result);
            //插入 表3



            //wordApp.Selection.EndKey(ref unite, ref Nothing); //将光标移动到文档末尾
            //wordDoc.Content.InsertAfter("\n");
            //wordDoc.Content.InsertAfter("就写这么多，算了吧！2016.09.27");

            //wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            //wordDoc.Paragraphs.Last.Range.Text = "我需要居中";
            //wordDoc.Paragraphs.Add(ref Nothing);
            //wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            //wordDoc.Paragraphs.Last.Range.Text = "我需要右对齐";
        }
        /// <summary>
        /// 填充各项内容
        /// </summary>
        /// <param name="filePath"></param>
        public void FillTestItems(int index, string title, string tmethod, string rules, string records, string result)
        {
            string strContent;
            Object Nothing = Missing.Value;
            object unite = MSWord.WdUnits.wdStory;

            wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)10.5;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";
            strContent = index.ToString() + "．" + title + "\n";
            wordDoc.Paragraphs.Last.Range.Text = strContent;
            //新建表格
            //插入表格
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordApp.Selection.ParagraphFormat.FirstLineIndent = 0;//首行缩进的长度
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)10.5;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";

            //wordDoc.Content.InsertAfter("\n");//这一句与下一句的顺序不能颠倒，原因还没搞透
            wordApp.Selection.EndKey(ref unite, ref Nothing); //将光标移动到文档末尾
            wordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;
            //设置表格的行数和列数
            int tableRow = 1;
            int tableColumn = 2;
            //定义一个Word中的表格对象
            MSWord.Table table = wordDoc.Tables.Add(wordApp.Selection.Range, tableRow, tableColumn, ref Nothing, ref Nothing);
            //默认创建的表格没有边框，这里修改其属性，使得创建的表格带有边框 
            table.Borders.Enable = 1;//这个值可以设置得很大，例如5、13等等

            table.Cell(1, 1).Range.Text = "检测项目";
            table.Cell(1, 2).Range.Text = title;

            //添加行
            table.Rows.Add(ref Nothing);
            table.Cell(2, 1).Range.Text = "测试方法或要求";
            table.Cell(2, 2).Range.Text = tmethod;

            table.Rows.Add(ref Nothing);
            table.Cell(3, 1).Range.Text = "判定准则";
            table.Cell(3, 2).Range.Text = rules;

            table.Rows.Add(ref Nothing);
            table.Cell(4, 1).Range.Text = "测试记录";
            table.Cell(4, 2).Range.Text = records;

            table.Rows.Add(ref Nothing);
            table.Cell(5, 1).Range.Text = "判定结果";
            table.Cell(5, 2).Range.Text = result;


            //设置table样式
            table.Rows.HeightRule = MSWord.WdRowHeightRule.wdRowHeightAtLeast;//高度规则是：行高有最低值下限？
            //table.Rows.Height = wordApp.CentimetersToPoints(float.Parse("0.8"));// 

            table.Range.Font.Size = 10.5F;
            table.Range.Font.Bold = 0;

            table.Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;//表格文本居中
            table.Range.Cells.VerticalAlignment = MSWord.WdCellVerticalAlignment.wdCellAlignVerticalCenter;//文本垂直贴到底部
            //设置table边框样式            
            table.Borders.InsideLineStyle = MSWord.WdLineStyle.wdLineStyleSingle;//表格内框是单线


            table.Columns[1].Width = (float)98.93;//将第 1列宽度设置为50
            table.Columns[2].Width = (float)315.78;
            //第二行开始最后列居左
            for (int i = 2; i <= 5; i++)
            {
                table.Cell(i, 2).Range.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;
            }
            wordDoc.Paragraphs.Last.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Size = (float)10.5;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";

            wordDoc.Paragraphs.Last.Range.InsertParagraphAfter();//插入回车

        }
    }

}
