using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Word;

namespace DemoWord01.Utility
{
    /// <summary>
    /// word操作类
    /// </summary>
    public class DocHelper
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

        /// <summary>
        /// 通过模板创建新文件
        /// </summary>
        /// <param name="filePath"></param>
        public void CreateNewDocument(string filePath)
        {
            //killWnWordProcess();
            wordApp = new ApplicationClass();
            wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            wordApp.Visible = false;
            object missing = System.Reflection.Missing.Value;
            object templateName = filePath;
            wordDoc = wordApp.Documents.Open(ref templateName, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing);
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
        /// 在书签处插入值
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="value">要插入的值</param>
        /// <returns></returns>
        public bool InsertValue(string bookmark, string value)
        {
            object bkObj = bookmark;
            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
            {
                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();
                wordApp.Selection.TypeText(value);
                return true;
            }
            return false;
        }

        /// <summary>
        ///插入表格
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public Table InsertTable(string bookmark, int rows, int columns, float width)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            Range range = wordDoc.Bookmarks.get_Item(ref oStart).Range; //表格插入位置
            Table newTable = wordDoc.Tables.Add(range, rows, columns, ref miss, ref miss);
            newTable.Borders.Enable = 1;//允许有边框，默认没有边框，（1，实现边框，2/3，虚线边框）
            newTable.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth050pt;//边框宽度
            if (width != 0)
            {
                newTable.PreferredWidth = width; //表格宽度
            }
            newTable.AllowPageBreaks = false;
            return newTable;
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="row1">开始行号</param>
        /// <param name="column1">开始列号</param>
        /// <param name="row2">结束行号</param>
        /// <param name="column2">结束列号</param>
        public void MergeCell(Microsoft.Office.Interop.Word.Table table, int row1, int column1, int row2, int column2)
        {
            table.Cell(row1, column1).Merge(table.Cell(row2, column2));
        }
        /// <summary>
        /// 设置表格内容对齐方式
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="Align">水平方向：-1，左对齐；0,居中；1,右对齐</param>
        /// <param name="Vertical">垂直方向：-1，顶端;0,居中；1,底端</param>
        public void SetParagraph_Table(Microsoft.Office.Interop.Word.Table table, int Align, int Vertical)
        {
            switch (Align)
            {
                case -1:
                    table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    break;
                case 0:
                    table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    break;
                case 1:
                    table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    break;
            }
            switch (Vertical)
            {
                case -1:
                    table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalTop;
                    break;
                case 0:
                    table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    break;
                case 1:
                    table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                    break;
            }
        }

        /// <summary>
        /// 设置表格字体
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fontName"></param>
        /// <param name="size"></param>
        public void SetFont_Table(Microsoft.Office.Interop.Word.Table table, string fontName, double size)
        {
            if (size != 0)
            {
                table.Range.Font.Size = Convert.ToSingle(size);
            }
            if (fontName != "")
                table.Range.Font.Name = fontName;
        }

        /// <summary>
        /// 是否使用边框
        /// </summary>
        /// <param name="n">表格的序号</param>
        /// <param name="use">是或否</param>
        public void UseBroder(int n, bool use)
        {
            if (use)
                wordDoc.Content.Tables[n].Borders.Enable = 1;
            else
                wordDoc.Content.Tables[n].Borders.Enable = 2;
        }

        /// <summary>
        /// 给第n个表格添加行
        /// </summary>
        /// <param name="n"></param>
        public void AddRow(int n)
        {
            object miss = System.Reflection.Missing.Value;
            wordDoc.Content.Tables[n].Rows.Add(ref miss);
        }

        /// <summary>
        /// 给表格添加一行
        /// </summary>
        /// <param name="table"></param>
        public void AddRows(Microsoft.Office.Interop.Word.Table table)
        {
            object miss = System.Reflection.Missing.Value;
            table.Rows.Add(ref miss);
        }
        /// <summary>
        /// 给表格添加行
        /// </summary>
        /// <param name="n">第n个表格</param>
        /// <param name="rows">添加的行数</param>
        public void AddRow(int n, int rows)
        {
            object miss = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            for (int i = 0; i < rows; i++)
            {
                table.Rows.Add(ref miss);
            }
        }
        /// <summary>
        /// 填充表格的单元格
        /// </summary>
        /// <param name="table">表格</param>
        /// <param name="row">行号</param>
        /// <param name="column">列号</param>
        /// <param name="value">插入的内容</param>
        public void InsertCell(Microsoft.Office.Interop.Word.Table table, int row, int column, string value)
        {
            table.Cell(row, column).Range.Text = value;
        }

        /// <summary>
        /// 给文档中第n个表格插入内容
        /// </summary>
        /// <param name="n"></param>
        /// <param name="row">行号</param>
        /// <param name="column">列号</param>
        /// <param name="value">插入的内容</param>
        public void InsertCell(int n, int row, int column, string value)
        {
            wordDoc.Content.Tables[n].Cell(row, column).Range.Text = value;

        }

        /// <summary>
        /// 给表格插入一行数据
        /// </summary>
        /// <param name="n">文档中表格的序号</param>
        /// <param name="row">行号</param>
        /// <param name="columns">列数</param>
        /// <param name="values">插入的值</param>
        public void InsertCell(int n, int row, int columns, string[] values)
        {
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            for (int i = 0; i < columns; i++)
                table.Cell(row, i + 1).Range.Text = values[i];
        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="picturePath"></param>
        /// <param name="width"></param>
        /// <param name="hight"></param>
        public void InsertPicture(string bookmark, string picturePath, float width, float hight)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            object linkToFile = false; //图片不为外部链接
            object saveWithDocment = true; //图片随文档一起保存
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range; //图片插入位置
            wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocment, ref range);
            wordDoc.Application.ActiveDocument.InlineShapes[1].Width = width;
            wordDoc.Application.ActiveDocument.InlineShapes[1].Height = hight;
        }
        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="picturePath"></param>
        public void InsertPicture(string bookmark, string picturePath)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            object linkToFile = false; //图片不为外部链接
            object saveWithDocment = true; //图片随文档一起保存
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range; //图片插入位置
            wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocment, ref range);
        }

        /// <summary>
        /// 插入一段文字
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="text"></param>
        public void InsertText(string bookmark, string text)
        {
            object oStart = bookmark;
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;
            Paragraph wp = wordDoc.Content.Paragraphs.Add(ref range);
            wp.Format.SpaceBefore = 6;
            wp.Range.Text = text;
            wp.Format.SpaceAfter = 24;
            wp.Range.InsertParagraphAfter();
            wordDoc.Paragraphs.Last.Range.Text = "\n";
        }

        /// <summary>
        /// 关闭Word进程
        /// </summary>
        public void killWnWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }
    }
}
