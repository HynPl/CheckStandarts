using System.Collections.Generic;
using System.Diagnostics;

namespace CheckStandarts.Excel {
    public class Sheet {
        internal class CellLoc{ 
            public Cell Cell;
            public int PosX, PosY;
        }

        internal List<CellLoc> Cells;
        internal string Name="sheet1";
        internal List<(Column, int)> Columns;
        List<(Row, int)> Rows;

        public Sheet(){ 
            Cells=new List<CellLoc>();
            Columns=new List<(Column,int)>();
            Rows=new List<(Row,int)>();
        }

        public void CellSet(int posX, int posY, string str, string styleName="") { 
            Cell cell=CellGet(posX, posY);
            if (cell==null) { 
                cell=new Cell();
                Cells.Add(new CellLoc{ Cell=cell, PosX=posX, PosY=posY});
            }
            cell.Text=str;
            cell.StyleName=styleName;
        }

        public Cell CellGet(int posX, int posY) { 
            foreach (CellLoc cell in Cells) { 
                if (cell.PosX==posX){ 
                    if (cell.PosY==posY) { 
                        return cell.Cell;
                    }
                }
            }
            return null;
        }
        
        public string CellRead(int posX, int posY) { 
            foreach (CellLoc cell in Cells) { 
                if (cell.PosX==posX){ 
                    if (cell.PosY==posY) { 
                        return cell.Cell.Text;
                    }
                }
            }
            return null;
        }

        public void ColumnWidthSet(int posX, double width) { 
            foreach ((Column, int) c in Columns) { 
                if (c.Item2==posX) { 
                    c.Item1.Width=width;
                    return;
                }
            }
            
            Columns.Add((new Column{ Width=width }, posX));
        }

        public double ColumnWidthGet(int posX) { 
            foreach ((Column, int) c in Columns) { 
                if (c.Item2==posX) { 
                    return c.Item1.Width;
                }
            }
            
            return -1;
        }

        internal List<List<CellLoc>> GetRowsWithCells() {  
            List<List<CellLoc>> table=new List<List<CellLoc>>();
            foreach (CellLoc c in Cells) { 
                Debug.WriteLine(c.PosX+" "+c.PosY);

                // solve capacity
                if (table.Count<=c.PosY) { 
                    for (int i=table.Count; i<=c.PosY; i++) table.Add(new List<CellLoc>());
                }
           //     Debug.WriteLine(c.PosX+" "+c.PosY);
                List<CellLoc> row = table[c.PosY];
                
                // solve capacity
                if (row.Count<=c.PosX) { 
                    for (int i=row.Count; i<=c.PosX; i++) row.Add(null);
                }

                // Add
                row[c.PosX]=c; 
            }    

            return table;
        }

    }
}
