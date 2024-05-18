using OfficeOpenXml;
using TripPlanner.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TripPlanner.Helper
{
    public class ExcelHelper
    {
        public List<HouseState> ReadExcel(Stream fileStream)
        {
            List<HouseState> dataList = new List<HouseState>();

            using (var package = new ExcelPackage(fileStream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first worksheet

                if (worksheet == null)
                {
                    throw new Exception("No worksheet found in the Excel file.");
                }

                int rowCount = worksheet.Dimension?.Rows ?? 0;
                if (rowCount == 0)
                {
                    throw new Exception("Worksheet is empty.");
                }
                // Adjust the end condition to exclude the last three rows
                int endRow = rowCount - 5;
                for (int row = 13; row <= endRow; row++) // Start from row 13
                {
                    try
                    {
                        var dateCell = worksheet.Cells[row, 1].Value;
                        var freePercentage1Cell = worksheet.Cells[row, 3].Value;
                        var occupiedPercentage1Cell = worksheet.Cells[row, 7].Value;
                        var accommodationCell = worksheet.Cells[row, 38].Value;
                        var FB = worksheet.Cells[row, 39].Value;
                        // Skip this row if any cell is null
                        if (dateCell == null || freePercentage1Cell == null || occupiedPercentage1Cell == null || accommodationCell == null || FB == null)
                        {
                            continue;
                        }

                        // Convert date cell value to string
                        string houseDate = dateCell.ToString();

                        // Try to parse percentage and accommodation cell values to decimal
                        if (!decimal.TryParse(freePercentage1Cell.ToString(), out decimal freePercentage1) ||
                            !decimal.TryParse(occupiedPercentage1Cell.ToString(), out decimal occupiedPercentage1) ||
                            !decimal.TryParse(accommodationCell.ToString(), out decimal accommodation) ||
                            !decimal.TryParse(FB.ToString(), out decimal FBs))
                        {
                            continue; // Skip if any decimal parsing fails
                        }

                        // Create a new HouseState object with the parsed values
                        HouseState data = new HouseState
                        {
                            HouseDate = houseDate,
                            FreePercentage1 = freePercentage1,
                            occupied = occupiedPercentage1,
                            Accommodation = accommodation,
                            FANDB = FBs
                        };

                        // Add the data object to the dataList
                        dataList.Add(data);
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception if needed
                        Console.WriteLine($"Error processing row {row}: {ex.Message}");
                        continue; // Continue to the next row on error
                    }
                }

                return dataList;
            }
        }
    }
}
