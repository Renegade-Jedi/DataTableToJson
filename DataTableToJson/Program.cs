using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                try
                {
                    int Row_Count_Line = 1;
                    JSON_Output_1 = JSON_Output_1.Concat("{");

                    // ######################## Fill the JSON WithOut Line Item ############################################'
                    foreach (System.Data.DataRow kvp in dt_Raw.Rows)
                    {
                        string v1 = kvp["Column1"].ToString();
                        string v2 = kvp["Column2"].ToString();

                        // 'system.Windows.MessageBox.Show("Key=>"+v1.ToString)
                        // 'system.Windows.MessageBox.Show("Value=>"+v2.ToString)
                        if (!v1.ToString().ToLower().Contains("lineitems"))
                        {
                            JSON_Output_1 = JSON_Output_1 + "\"" + v1 + "\"" + ":" + "\"" + v2.ToString() + "\"" + "," + Environment.NewLine;
                        }
                    }

                    JSON_Output_1 = JSON_Output_1.Remove(JSON_Output_1.ToString.Length - 3, 1);
                    JSON_Output_1 = JSON_Output_1 + "}";
                    // 'system.Windows.MessageBox.Show(JSON_Output_1)


                    // ######################## End OF Fill the JSON WithOut Line Item ############################################'
                    string First_Line_Item_KeyWord = null;

                    // ###Logic To find the First Line Item Keyword#########
                    foreach (System.Data.DataRow kvp in dt_Raw.Rows)
                    {
                        string v1 = kvp["Column1"].ToString();
                        string v2 = kvp["Column2"].ToString();
                        if (v1.ToString().ToLower().Contains("lineitems"))
                        {
                            First_Line_Item_KeyWord = v1.ToString().ToLower();
                            break;
                        }
                    }
                    // ### End of Logic To find the First Line Item Keyword######

                    // ######################## Logic for Line item-2 ############################################'

                    JSON_Output_2 = "{" + Environment.NewLine + "\"" + "LineItems" + "\"" + ":" + "{";
                    int Enter_Else_part = 0;
                    foreach (System.Data.DataRow kvp in dt_Raw.Rows)
                    {
                        string v1 = kvp["Column1"].ToString();
                        string v2 = kvp["Column2"].ToString();
                        if (v1.ToString().ToLower().Equals(First_Line_Item_KeyWord) | v1.ToString().ToLower().Contains("lineitems"))
                        {
                            if (v1.ToString().ToLower().Equals(First_Line_Item_KeyWord))
                            {
                                if (Enter_Else_part == 1)
                                {
                                    // 'system.Windows.MessageBox.Show("Enter Else part"+JSON_Output_2)
                                    JSON_Output_2 = JSON_Output_2.Remove(JSON_Output_2.ToString.Length - 1, 1) + "],";
                                    Enter_Else_part = 0;
                                }

                                JSON_Output_2 = JSON_Output_2 + "\"" + "Line" + Row_Count_Line.ToString() + "\"" + ":[" + Environment.NewLine;
                                JSON_Output_2 = JSON_Output_2 + "{" + "\"" + v1.ToString() + "\"" + ":" + "\"" + v2.ToString() + "\"" + "},";
                                // 'system.Windows.MessageBox.Show("then Part"+JSON_Output_2)
                                Row_Count_Line = Row_Count_Line + 1;
                            }
                            else
                            {
                                JSON_Output_2 = JSON_Output_2 + "{" + "\"" + v1.ToString() + "\"" + ":" + "\"" + v2.ToString() + "\"" + "},";
                                // 'system.Windows.MessageBox.Show("Else Part "+JSON_Output_2)

                                Enter_Else_part = 1;
                            }
                        }
                    }

                    JSON_Output_2 = JSON_Output_2.Remove(JSON_Output_2.ToString.Length - 1, 1);
                    JSON_Output_2 = JSON_Output_2 + "]}" + Environment.NewLine + "}";
                }

                // 'system.Windows.MessageBox.Show(JSON_Output_2)
                // ######################## End of Logic line item-2 ############################################'



                catch (Exception es)
                {
                    System.Windows.MessageBox.Show(es.Message);
                }
            }

        }
    }
}
