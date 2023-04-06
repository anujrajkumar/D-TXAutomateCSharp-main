using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.Utilities
{
    public class ExcelUtil
    {
        public string path;
        public FileStream? fs = null;
        private XSSFWorkbook? workbook = null;
        private ISheet? sheet = null;
        private IRow? row = null;
        private ICell? cell = null;
        public static CommonSettings cs = new CommonSettings();

        public ExcelUtil(string path)
        {
            try
            {
                this.path = path;
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                    workbook = new XSSFWorkbook(fs);
                    sheet = workbook.GetSheetAt(0);
                    fs.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public int getRowCount(string sheetName)
        {
            try
            {
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return 0;
                else
                {
                    sheet = workbook.GetSheetAt(index);
                    int number = sheet.LastRowNum + 1;
                    return number;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int getColumnCount(string sheetName)
        {
            try
            {
                if (!isSheetExist(sheetName))
                    return -1;
                sheet = workbook.GetSheet(sheetName);
                row = sheet.GetRow(0);
                if (row == null)
                    return -1;
                return row.LastCellNum;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        public int getRowNumber(string sheetName, int colNum, string value)
        {
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(fs);
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return 0;

                sheet = workbook.GetSheetAt(index);
                for (int rw = 0; rw < sheet.LastRowNum; rw++)
                {
                    if (sheet.GetRow(rw) != null)
                    {
                        row = sheet.GetRow(rw);
                    }
                }
                return row.RowNum;
            }
            catch (Exception)
            {
                return row.RowNum;
            }
        }
        public string getCellData(string sheetName, int colNum, int rowNum)
        {
            try
            {
                if (rowNum <= 0)
                    return "";
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return "";
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(rowNum - 1);
                if (row == null)
                    return "";
                cell = row.GetCell(colNum);
                if (cell == null)
                    return "";
                if (cell.CellType == CellType.String)
                    return cell.StringCellValue;
                else if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
                {
                    string cellText = Convert.ToString(cell.NumericCellValue);
                    return cellText;
                }
                else if (cell.CellType == CellType.Blank)
                    return "";
                else
                    return cell.BooleanCellValue.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return "";
            }
        }
        public string getCellData(string sheetName, string colName, int rowNum)
        {
            try
            {
                if (rowNum <= 0)
                    return "";
                int colNum = -1;
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return "";
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(0);
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    if (row.GetCell(i).StringCellValue.Trim().Equals(colName.Trim()))
                    {
                        colNum = i;
                    }
                }
                if (colNum == -1)
                    return "";
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(rowNum - 1);
                if (row == null)
                    return "";
                cell = row.GetCell(colNum);
                if (cell == null)
                    return "";
                if (cell.CellType == CellType.String)
                    return cell.StringCellValue;
                else if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
                {
                    string cellText = Convert.ToString(cell.NumericCellValue);
                    return cellText;
                }
                else if (cell.CellType == CellType.Blank)
                    return "";
                else
                    return cell.BooleanCellValue.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string setCellData(string sheetName, string colName, int rowNum, string data)
        {
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                workbook = new XSSFWorkbook(fs);
                if (rowNum <= 0)
                    return "";
                int colNum = -1;
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return "";
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(0);
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    if (row.GetCell(i).StringCellValue.Equals(colName))
                    {
                        colNum = i;
                    }
                }
                if (colNum == -1)
                    return "";
                row = sheet.GetRow(rowNum - 1);
                if (row == null)
                    row = sheet.CreateRow(rowNum - 1);
                cell = row.GetCell(colNum);
                if (cell == null)
                    cell = row.CreateCell(colNum);

                ICellStyle cs = workbook.CreateCellStyle();
                cs.WrapText = true;
                cell.CellStyle = cs;
                cell.SetCellValue(data);

                FileStream f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                workbook.Write(f);
                f.Close();
                fs.Close();
                return data;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string setCellData(string sheetName, int colNum, int rowNum, string data)
        {
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(fs);
                if (rowNum <= 0)
                    return "";
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return "";
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(rowNum - 1);
                if (row == null)
                    row = sheet.CreateRow(rowNum - 1);
                cell = row.GetCell(colNum);
                if (cell == null)
                    cell = row.CreateCell(colNum);
                ICellStyle cs = workbook.CreateCellStyle();
                cs.WrapText = true;
                cell.CellStyle = cs;
                cell.SetCellValue(data);
                FileStream f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                workbook.Write(f);
                f.Close();
                fs.Close();
                return data;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public bool addSheet(string sheetName)
        {
            try
            {
                workbook.CreateSheet(sheetName);
                fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                workbook.Write(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool removeSheet(string sheetName)
        {
            int index = workbook.GetSheetIndex(sheetName);
            if (index == -1)
                return false;
            try
            {
                workbook.RemoveSheetAt(index);
                fs = new FileStream(path, FileMode.Truncate);
                workbook.Write(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool addColumn(string sheetName, string colName)
        {
            try
            {
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(fs);
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                    return false;
                ICellStyle cs = workbook.CreateCellStyle();
                sheet = workbook.GetSheetAt(index);
                row = sheet.GetRow(0);
                if (row == null)
                    row = sheet.CreateRow(0);
                cell = row.GetCell(0);
                if (cell == null)
                    cell = row.CreateCell(0);
                else
                    cell = row.CreateCell(row.LastCellNum);
                cell.SetCellValue(colName);
                cell.CellStyle = cs;

                FileStream f = new FileStream(path, FileMode.Create);
                workbook.Write(f);
                f.Close();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool removeColumn(string sheetName, int colNum)
        {
            try
            {
                if (!isSheetExist(sheetName))
                    return false;
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(fs);
                sheet = workbook.GetSheet(sheetName);
                ICellStyle cs = workbook.CreateCellStyle();
                for (int i = 0; i < getRowCount(sheetName); i++)
                {
                    row = sheet.GetRow(i);
                    if (row != null)
                    {
                        cell = row.GetCell(colNum - 1);
                        if (cell != null)
                        {
                            cell.CellStyle = cs;
                            row.RemoveCell(cell);
                        }
                    }
                }
                FileStream f = new FileStream(path, FileMode.Truncate);
                workbook.Write(f);
                f.Close();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool isSheetExist(string sheetName)
        {
            try
            {
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                {
                    index = workbook.GetSheetIndex(sheetName.ToUpper());
                    if (index == -1)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int getCellRowNum(string sheetName, string colName, string cellValue)
        {
            try
            {
                for (int i = 0; i < getRowCount(sheetName); i++)
                {
                    if (getCellData(sheetName, colName, i).Equals(cellValue))
                    {
                        return i;
                    }
                }
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        /// <summary>
        /// Desc:Method is used to get data from excel using NPOI
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static object[] getData(ExcelUtil xls, string sheetName)
        {
            try
            {
                int rows = xls.getRowCount(sheetName);
                Console.WriteLine("Total rows :" + rows);
                int cols = xls.getColumnCount(sheetName);
                Console.WriteLine("Total cols :" + cols);
                object[][] data = new object[rows - 1][];
                int dataRow = 0;
                Dictionary<string, string> table = null;
                for (int rNum = 2; rNum <= rows; rNum++)
                {
                    data[rNum - 2] = new object[1];
                    table = new Dictionary<string, string>();
                    for (int cNum = 0; cNum < cols; cNum++)
                    {
                        string key = xls.getCellData(sheetName, cNum, 1);
                        string value = xls.getCellData(sheetName, cNum, rNum);
                        table.Add(key, value);
                    }
                    data[dataRow][0] = table;
                    dataRow++;
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Desc:Method is used to get data from excel using NPOI
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static List<Dictionary<string, string>> getDataInDictionaryForm(ExcelUtil xls, string sheetName)
        {
            try
            {
                int rows = xls.getRowCount(sheetName);
                int cols = xls.getColumnCount(sheetName);
                object[][] data = new object[rows - 1][];
                int dataRow = 0;
                List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();
                for (int rNum = 2; rNum <= rows; rNum++)
                {
                    data[rNum - 2] = new object[1];
                    Dictionary<string, string> table_1 = new Dictionary<string, string>();
                    table_1.Add("currentRowNum", rNum.ToString());
                    for (int cNum = 0; cNum < cols; cNum++)
                    {
                        string key = xls.getCellData(sheetName, cNum, 1);
                        string value = xls.getCellData(sheetName, cNum, rNum);
                        table_1.Add(key, value);
                    }
                    table.Add(table_1);
                    data[dataRow][0] = table;
                    dataRow++;
                }
                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string dataFromTestDataExcelCell(string testDataName, string sheetName, string columnName)
        {
            string dataFromCell = null;
            try
            {
                var data = getDataInDictionaryForm(new ExcelUtil(FileFolderUtil.GetTestDataExcelPath()), sheetName);
                foreach (var _data in data)
                {
                    if (_data[ColumnParam.testDataColumnName].Equals(testDataName))
                    {
                        dataFromCell = _data[columnName];
                    }
                }
            }
            catch (Exception e)
            {
                LogUtil.ErrorLog(e.Message);
            }
            if (dataFromCell != null)
            {
                LogUtil.infoLog("Data from column " + columnName + " is - " + dataFromCell + " for test data name - " + testDataName + " in excel sheet name - " + sheetName);
            }
            
            return dataFromCell;
        }

        public static List<Dictionary<string, string>> getTestDataFromSheet(string sheetName)
        {
            LogUtil.infoLog("Storing data from sheet - " + sheetName);
            ExtentUtil.LogInfo("Storing data from sheet - " + sheetName);
            List <Dictionary<string, string>> table = getDataInDictionaryForm(new ExcelUtil(FileFolderUtil.GetTestDataExcelPath()), sheetName);

                return table;
        }

        public static string getTestDataUsingDataAndColumn(List<Dictionary<string, string>> keyValuePairs, string testDataName, string columnName)
        {
            string dataFromCell = null;
            foreach (var _data in keyValuePairs)
            {
                if (_data[ColumnParam.testDataColumnName].Equals(testDataName))
                {
                    dataFromCell = _data[columnName];
                }
            }

            if (dataFromCell != null)
            {
                LogUtil.infoLog("Data from column " + columnName + " is - " + dataFromCell + " for test data name - " + testDataName + " in excel.");
                ExtentUtil.LogInfo("Data from column " + columnName + " is - " + dataFromCell + " for test data name - " + testDataName + " in excel.");
            }

            return dataFromCell.Trim();
        }

        public static void dataFromAutomationExcelSheetCell()
        {
            try
            {
                IWorkbook workbook = null;
                List<string> cellData = new List<string>();
                FileStream fs = new FileStream(FileFolderUtil.GetAutomationControlSheetExcelPath(), (FileMode)FileAccess.ReadWrite);
                workbook = new XSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheet(CommonConstants.automationControlExcelDataSheetName);
                if (sheet != null)
                {
                    int rowCount = sheet.LastRowNum;
                    for (int i = 1; i <= rowCount; i++)
                    {
                        IRow curRow = sheet.GetRow(i);
                        if (curRow == null)
                        {
                            rowCount = i - 1;
                            break;
                        }
                        var cellValue = curRow.GetCell(1).StringCellValue.Trim();
                        cellData.Add(cellValue);
                    }
                }

                cs.projectName = cellData[0];
                cs.environmentName = cellData[1];
                cs.buildNumber = cellData[2];
                cs.URL = cellData[3];
                cs.excutionEnvironment = cellData[5];
                cs.cloudProvider = cellData[6];
                cs.cloudProviderURL = cellData[7];
                cs.hostUsername = cellData[8];
                cs.key = cellData[9];
                cs.os = cellData[10];
                cs.browser = cellData[11];
                cs.dbConfigFlag = cellData[13];
                cs.dbEnv = cellData[14];
                cs.dbDataSource = cellData[15];
                cs.dbName = cellData[16];
                cs.dbAuthFlag = cellData[17];
                cs.dbUsername = cellData[18];
                cs.dbPassword = cellData[19];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
