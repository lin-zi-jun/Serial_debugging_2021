using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace 上位机服务器
{
    class SGY_Change : SGY_File
    {

        public static string Head_f_com = "C 1   This tape was made at the                                                 C 2                                                                             C 3   Center for Wave Phenomena                                                 C 4   Colorado School of Mines                                                  C 5   Golden, CO, 80401                                                         C 6                                                                             C 7                                                                             C 8                                                                             C 9                                                                             C10                                                                             C11                                                                             C12                                                                             C13                                                                             C14                                                                             C15                                                                             C16                                                                             C17                                                                             C18                                                                             C19                                                                             C20                                                                             C21                                                                             C22                                                                             C23                                                                             C24                                                                             C25                                                                             C26                                                                             C27                                                                             C28                                                                             C29                                                                             C30                                                                             C31                                                                             C32                                                                             C33                                                                             C34                                                                             C35                                                                             C36                                                                             C37                                                                             C38                                                                             C39                                                                             C40   END EBCDIC                                                                                    ";
        /// <summary>
        /// sgy转换函数
        /// </summary>
        /// <param name="filename">要打开的文件绝对路径</param>
        /// <param name="writename">要保存的文件绝对路径</param>
        /// <returns>成功返回true；失败返回false；</returns>
        public static bool Change(string filename, string writename)
        {
            try
            {
                FileStream rs = File.Open(filename, FileMode.Open);
                ushort nso_num = (ushort)(rs.Length / 4);
                byte[] readtmp = new byte[nso_num * 4];
                rs.Read(readtmp, 0, nso_num * 4);
                rs.Close();
                int[] sgynum = new int[nso_num];
                sgynum = BytesToArray(readtmp, sgynum);
                SGY_File.SGY_data sgytmp = new SGY_File.SGY_data();      //实例化一个sgy_data；
                sgytmp.Head_f = Head_f_com;
                sgytmp.head_se.ntrpr = sgytmp.head_se.nart = 1;      //设置sgy的道数，从1开始，即采样通道数，同时间采了多少数据
                sgytmp.head_se.hns = sgytmp.head_se.nso = nso_num;          //设置sgy的采样点数
                sgytmp.head_se.hdt = sgytmp.head_se.dto = 250;           //设置sgy的采样间隔时间（us）（1/采样频率）
                sgytmp.head_se.format = 5;                                              //设置sgy的数据类型：5表示float；
                sgytmp.daoju = new SU_data[1];          //实例化SU_data
                sgytmp.daoju[0].daotou.tracl = 0;                        //设置每道的道号，从0开始
                sgytmp.daoju[0].daotou.tracr = 1;                 //设置每道的CMP号，从1开始
                sgytmp.daoju[0].sgynum = new float[sgytmp.head_se.hns];    //实例化每道的数据
                for (int i = 0; i < sgytmp.head_se.hns; ++i)             //写入sgytmp.daoju[0].sgynum数组
                {
                    sgytmp.daoju[0].sgynum[i] = (float)((float)sgynum[i] * 1.25 / 0x7fffffff); ;
                }
                Write(sgytmp, writename);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
