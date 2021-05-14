using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 上位机服务器
{
    public class SGY_File
    {
        /// <summary>
        /// SEGY卷头文件中400字节数据信息用Struct_reelb400结构体读取
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 400, Pack = 1)]
        public struct Struct_400
        { /* bhed - binary header */
            /// <summary>
            /// 
            /// </summary>
            public int jobid;/* job identification number */
            public int lino; /* line number (only one line per reel) */
            public int reno; /* reel number */
            public short ntrpr; /* number of data traces per record */
            public short nart; /* number of auxiliary traces per record */
            public ushort hdt; /* sample interval in micro secs for this reel */
            public ushort dto; /* same for original field recording */
            public ushort hns; /* number of samples per trace for this reel */
            public ushort nso; /* same for original field recording */
            public short format; /* data sample format code: 
                                        1 = floating point (4 bytes) 
                                        2 = fixed point (4 bytes) 
                                        3 = fixed point (2 bytes) 
                                        4 = fixed point w/gain code (4 bytes) */
            public short fold; /* CDP fold expected per CDP ensemble */
            public short tsort; /* trace sorting code: 
                                        1 = as recorded (no sorting) 
                                        2 = CDP ensemble 
                                        3 = single fold continuous profile 
                                        4 = horizontally stacked */
            public short vscode; /* vertical sum code: 
                                        1 = no sum 
                                        2 = two sum ... 
                                        N = N sum (N = 32,767) */
            public short hsfs; /* sweep frequency at start */
            public short hsfe; /* sweep frequency at end */
            public short hslen; /* sweep length (ms) */
            public short hstyp; /* sweep type code: 
                                        1 = linear 
                                        2 = parabolic 
                                        3 = exponential 
                                        4 = other */
            public short schn; /* trace number of sweep channel */
            public short hstas; /* sweep trace taper length at start if 
                                        tapered (the taper starts at zero time 
                                        and is effective for this length) */
            public short hstae; /* sweep trace taper length at end (the ending 
                                        taper starts at sweep length minus the taper 
                                        length at end) */
            public short htatyp; /* sweep trace taper type code: 
                                        1 = linear 
                                        2 = cos-squared 
                                        3 = other */
            public short hcorr; /* correlated data traces code: 
                                        1 = no 
                                        2 = yes */
            public short bgrcv; /* binary gain recovered code: 
                                        1 = yes 
                                        2 = no */
            public short rcvm; /* amplitude recovery method code: 
                                        1 = none 
                                        2 = spherical divergence 
                                        3 = AGC 
                                        4 = other */
            public short mfeet; /* measurement system code: 
                                        1 = meters 
                                        2 = feet */
            public short polyt; /* impulse signal polarity code: 
                                        1 = increase in pressure or upward 
                                        geophone case movement gives 
                                        negative number on tape 
                                        2 = increase in pressure or upward 
                                        geophone case movement gives 
                                        positive number on tape */
            public short vpol; /* vibratory polarity code: 
                                        code seismic signal lags pilot by 
                                        1 337.5 to 22.5 degrees 
                                        2 22.5 to 67.5 degrees 
                                        3 67.5 to 112.5 degrees 
                                        4 112.5 to 157.5 degrees 
                                        5 157.5 to 202.5 degrees 
                                        6 202.5 to 247.5 degrees 
                                        7 247.5 to 292.5 degrees 
                                        8 293.5 to 337.5 degrees */
            [MarshalAs(UnmanagedType.ByValArray,SizeConst = 170)]
            public short[] hunass; //new short[170]; /* unassigned */
        };
        
        /// <summary>
        /// SU道头文件中头240个字节数据信息用Struct_SU240结构体读取
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Size = 240, Pack = 1)]
        public struct Struct_240
        {
            public int tracl; /* Trace sequence number within line 
                                        --numbers continue to increase if the 
                                        same line continues across multiple 
                                        SEG Y files.*/
            public int tracr; /* Trace sequence number within SEG Y file 
                                        ---each file starts with trace sequence 
                                        one*/
            public int fldr; /* Original field record number */
            public int tracf; /* Trace number within original field record */
            public int ep; /* energy source point number 
                                        ---Used when more than one record occurs 
                                        at the same effective surface location.*/
            public int cdp; /* Ensemble number (i.e. CDP, CMP, CRP,...) */
            public int cdpt; /* trace number within the ensemble 
                                        ---each ensemble starts with trace number one.*/
            public short trid; /* trace identification code: 
                                        -1 = Other 
                                        0 = Unknown 
                                        1 = Seismic data 
                                        2 = Dead 
                                        3 = Dummy 
                                        4 = Time break 
                                        5 = Uphole 
                                        6 = Sweep 
                                        7 = Timing 
                                        8 = Water break 
                                        9 = Near-field gun signature 
                                        10 = Far-field gun signature 
                                        11 = Seismic pressure sensor 
                                        12 = Multicomponent seismic sensor 
                                        - Vertical component 
                                        13 = Multicomponent seismic sensor 
                                        - Cross-line component 
                                        14 = Multicomponent seismic sensor 
                                        - in-line component 
                                        15 = Rotated multicomponent seismic sensor 
                                        - Vertical component 
                                        16 = Rotated multicomponent seismic sensor 
                                        - Transverse component 
                                        17 = Rotated multicomponent seismic sensor 
                                        - Radial component 
                                        18 = Vibrator reaction mass 
                                        19 = Vibrator baseplate 
                                        20 = Vibrator estimated ground force 
                                        21 = Vibrator reference 
                                        22 = Time-velocity pairs 
                                        23 ... N = optional use 
                                        (maximum N = 32,767) 
                                        Following are CWP id flags: 
                                        109 = autocorrelation 
                                        110 = Fourier transformed - no packing 
                                        xr[0],xi[0], ..., xr[N-1],xi[N-1] 
                                        111 = Fourier transformed - unpacked Nyquist 
                                        xr[0],xi[0],...,xr[N/2],xi[N/2] 
                                        112 = Fourier transformed - packed Nyquist 
                                        even N: 
                                        xr[0],xr[N/2],xr[1],xi[1], ..., 
                                        xr[N/2 -1],xi[N/2 -1] 
                                        (note the exceptional second entry) 
                                        odd N: 
                                        xr[0],xr[(N-1)/2],xr[1],xi[1], ..., 
                                        xr[(N-1)/2 -1],xi[(N-1)/2 -1],xi[(N-1)/2] 
                                        (note the exceptional second & last entries) 
                                        113 = Complex signal in the time domain 
                                        xr[0],xi[0], ..., xr[N-1],xi[N-1] 
                                        114 = Fourier transformed - amplitude/phase 
                                        a[0],p[0], ..., a[N-1],p[N-1] 
                                        115 = Complex time signal - amplitude/phase 
                                        a[0],p[0], ..., a[N-1],p[N-1] 
                                        116 = Real part of complex trace from 0 to Nyquist 
                                        117 = Imag part of complex trace from 0 to Nyquist 
                                        118 = Amplitude of complex trace from 0 to Nyquist 
                                        119 = Phase of complex trace from 0 to Nyquist 
                                        121 = Wavenumber time domain (k-t) 
                                        122 = Wavenumber frequency (k-omega) 
                                        123 = Envelope of the complex time trace 
                                        124 = Phase of the complex time trace 
                                        125 = Frequency of the complex time trace 
                                        130 = Depth-Range (z-x) traces 
                                        143 = Seismic Data, Vertical Component 
                                        144 = Seismic Data, Horizontal Component 1 
                                        145 = Seismic Data, Horizontal Component 2 
                                        146 = Seismic Data, Radial Component 
                                        147 = Seismic Data, Transverse Component 
                                        201 = Seismic data packed to bytes (by supack1) 
                                        202 = Seismic data packed to 2 bytes (by supack2) 
                                        */
            public short nvs; /* Number of vertically summed traces yielding 
                                        this trace. (1 is one trace, 
                                        2 is two summed traces, etc.)*/
            public short nhs; /* Number of horizontally summed traces yielding 
                                        this trace. (1 is one trace 
                                        2 is two summed traces, etc.)*/
            public short duse; /* Data use: 
                                        1 = Production 
                                        2 = Test*/
            public int offset; /* Distance from the center of the source point 
                                        to the center of the receiver group 
                                        (negative if opposite to direction in which 
                                        the line was shot).*/
            public int gelev; /* Receiver group elevation from sea level 
                                        (all elevations above the Vertical datum are 
                                        positive and below are negative).*/
            public int selev; /* Surface elevation at source. */
            public int sdepth; /* Source depth below surface (a positive number). */
            public int gdel; /* Datum elevation at receiver group. */
            public int sdel; /* Datum elevation at source. */
            public int swdep; /* Water depth at source. */
            public int gwdep; /* Water depth at receiver group. */
            public short scalel; /* Scalar to be applied to the previous 7 entries 
                                        to give the real value. 
                                        Scalar = 1, +10, +100, +1000, +10000. 
                                        If positive, scalar is used as a multiplier, 
                                        if negative, scalar is used as a divisor.*/
            public short scalco; /* Scalar to be applied to the next 4 entries 
                                        to give the real value. 
                                        Scalar = 1, +10, +100, +1000, +10000. 
                                        If positive, scalar is used as a multiplier, 
                                        if negative, scalar is used as a divisor.*/
            public int sx; /* Source coordinate - X */
            public int sy; /* Source coordinate - Y */
            public int gx; /* Group coordinate - X */
            public int gy; /* Group coordinate - Y */
            public short counit; /* Coordinate units: (for previous 4 entries and 
                                        for the 7 entries before scalel) 
                                        1 = Length (meters or feet) 
                                        2 = Seconds of arc 
                                        3 = Decimal degrees 
                                        4 = Degrees, minutes, seconds (DMS) 
                                        In case 2, the X values are longitude and 
                                        the Y values are latitude, a positive value designates 
                                        the number of seconds east of Greenwich 
                                        or north of the equator 
                                        In case 4, to encode +-DDDMMSS 
                                        counit = +-DDD*10^4 + MM*10^2 + SS, 
                                        with scalco = 1. To encode +-DDDMMSS.ss 
                                        counit = +-DDD*10^6 + MM*10^4 + SS*10^2 
                                        with scalco = -100.*/
            public short wevel; /* Weathering velocity. */
            public short swevel; /* Subweathering velocity. */
            public short sut; /* Uphole time at source in milliseconds. */
            public short gut; /* Uphole time at receiver group in milliseconds. */
            public short sstat; /* Source static correction in milliseconds. */
            public short gstat; /* Group static correction in milliseconds.*/
            public short tstat; /* Total static applied in milliseconds. 
                                        (Zero if no static has been applied.) */
            public short laga; /* Lag time A, time in ms between end of 240- 
                                        byte trace identification header and time 
                                        break, positive if time break occurs after 
                                        end of header, time break is defined as 
                                        the initiation pulse which maybe recorded 
                                        on an auxiliary trace or as otherwise 
                                        specified by the recording system */
            public short lagb; /* lag time B, time in ms between the time break 
                                        and the initiation time of the energy source, 
                                        may be positive or negative */
            public short delrt; /* delay recording time, time in ms between 
                                        initiation time of energy source and time 
                                        when recording of data samples begins 
                                        (for deep water work if recording does not 
                                        start at zero time) */
            public short muts; /* mute time--start */
            public short mute; /* mute time--end */
            public ushort ns; /* number of samples in this trace */
            public ushort dt; /* sample interval; in micro-seconds */
            public short gain; /* gain type of field instruments code: 
                                        1 = fixed 
                                        2 = binary 
                                        3 = floating point 
                                        4 ---- N = optional use */
            public short igc; /* instrument gain constant */
            public short igi; /* instrument early or initial gain */
            public short corr; /* correlated: 
                                        1 = no 
                                        2 = yes */
            public short sfs; /* sweep frequency at start */
            public short sfe; /* sweep frequency at end */
            public short slen; /* sweep length in ms */
            public short styp; /* sweep type code: 
                                        1 = linear 
                                        2 = cos-squared 
                                        3 = other */
            public short stas; /* sweep trace length at start in ms */
            public short stae; /* sweep trace length at end in ms */
            public short tatyp; /* taper type: 1=linear, 2=cos^2, 3=other */
            public short afilf; /* alias filter frequency if used */
            public short afils; /* alias filter slope */
            public short nofilf; /* notch filter frequency if used */
            public short nofils; /* notch filter slope */
            public short lcf; /* low cut frequency if used */
            public short hcf; /* high cut frequncy if used */
            public short lcs; /* low cut slope */
            public short hcs; /* high cut slope */
            public short year; /* year data recorded */
            public short day; /* day of year */
            public short hour; /* hour of day (24 hour clock) */
            public short minute; /* minute of hour */
            public short sec; /* second of minute */
            public short timbas; /* time basis code: 
                                        1 = local 
                                        2 = GMT 
                                        3 = other */
            public short trwf; /* trace weighting factor, defined as 1/2^N 
                                        volts for the least sigificant bit */
            public short grnors; /* geophone group number of roll switch 
                                        position one */
            public short grnofr; /* geophone group number of trace one within 
                                        original field record */
            public short grnlof; /* geophone group number of last trace within 
                                        original field record */
            public short gaps; /* gap size (total number of groups dropped) */
            public short otrav; /* overtravel taper code: 
                                        1 = down (or behind) 
                                        2 = up (or ahead) */
            /* cwp local assignments */
            public float d1; /* sample spacing for non-seismic data */
            public float f1; /* first sample location for non-seismic data */
            public float d2; /* sample spacing between traces */
            public float f2; /* first trace location */
            public float ungpow; /* negative of power used for dynamic range compression */
            public float unscale; /* reciprocal of scaling factor to normalize range */
            public int ntr; /* number of traces */
            public short mark; /* mark selected traces */
            public short shortpad; /* alignment padding */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public short[] unass;/*= new short[14];  unassigned--NOTE: last entry causes 
                                        a break in the word alignment, if we REALLY 
                                        want to maintain 240 bytes, the following 
                                        entry should be an odd number of short/UINT2 
                                        OR do the insertion above the "mark" keyword 
                                        entry */
        };

        /// <summary>
        /// SGY文件格式结构体
        /// </summary>
        public struct SGY_data      
        {
            /// <summary>
            /// 卷头第一部分3200字节
            /// </summary>
            public string Head_f;
            /// <summary>
            /// 卷头第二部分400字节
            /// </summary>
            public Struct_400 head_se;
            /// <summary>
            /// 道头240字节+数据
            /// </summary>
            public SU_data[] daoju;
        }


        /// <summary>
        /// 道头240字节+数据
        /// </summary>
        public struct SU_data
        {
            /// <summary>
            /// 道头240字节
            /// </summary>
            public Struct_240 daotou;
            /// <summary>
            /// 数据
            /// </summary>
            public float[] sgynum;
        }

        public struct Bin_Data
        {
            public byte fi;
            public byte se;
            public byte th;
            public byte fo;
        };

        [StructLayout(LayoutKind.Explicit)]
        public struct Yuan_Data
        {
            [FieldOffset(0)]
            public int num;
            [FieldOffset(0)]
            public Bin_Data Bin_num;
            public Yuan_Data(byte del)
            {
                num = 0;
                Bin_num.fi = 0;
                Bin_num.se = 0;
                Bin_num.th = 0;
                Bin_num.fo = 0;
            }
        };

        [StructLayout(LayoutKind.Explicit)]
        public struct Segy_Data
        {
            [FieldOffset(0)]
            public float num;
            [FieldOffset(0)]
            public Bin_Data Bin_num;
            public Segy_Data(byte del)
            {
                num = 0;
                Bin_num.fi = 0;
                Bin_num.se = 0;
                Bin_num.th = 0;
                Bin_num.fo = 0;
            }
        };

        /// <summary>
        /// 大小端数据转换函数重载
        /// </summary>
        /// <param name="tnf4">float类型</param>
        public static void swap(ref float tnf4) //swap_float_4
        {
            Segy_Data tmp = new Segy_Data(0);
            byte swtmp;
            tmp.num = tnf4;
            swtmp = tmp.Bin_num.fi; tmp.Bin_num.fi = tmp.Bin_num.fo; tmp.Bin_num.fo = swtmp;
            swtmp = tmp.Bin_num.se; tmp.Bin_num.se = tmp.Bin_num.th; tmp.Bin_num.th = swtmp;
            tnf4 = tmp.num;
        }

        /// <summary>
        /// 大小端数据转换函数重载
        /// </summary>
        /// <param name="tnf4">int32类型</param>
        public static void swap(ref int tnf4) //swap_float_4
        {
            Yuan_Data tmp = new Yuan_Data(0);
            byte swtmp;
            tmp.num = tnf4;
            swtmp = tmp.Bin_num.fi; tmp.Bin_num.fi = tmp.Bin_num.fo; tmp.Bin_num.fo = swtmp;
            swtmp = tmp.Bin_num.se; tmp.Bin_num.se = tmp.Bin_num.th; tmp.Bin_num.th = swtmp;
            tnf4 = tmp.num;
        }

        public static byte[] ArrayToBytes(int[] intObj)
        {
            int size = sizeof(int) * intObj.Length;
            byte[] bytes = new byte[size];
            IntPtr ObjToPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(intObj, 0, ObjToPtr, intObj.Length);
            Marshal.Copy(ObjToPtr, bytes, 0, size);
            Marshal.FreeHGlobal(ObjToPtr);
            return bytes;
        }

        public static byte[] ArrayToBytes(float[] floatObj)
        {
            int size = sizeof(float) * floatObj.Length;
            byte[] bytes = new byte[size];
            IntPtr ObjToPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(floatObj, 0, ObjToPtr, floatObj.Length);
            Marshal.Copy(ObjToPtr, bytes, 0, size);
            Marshal.FreeHGlobal(ObjToPtr);
            return bytes;
        }

        public static byte[] StructToBytes(object structObj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return bytes;
        }

        public static object BytesToStuct(byte[] bytes, Type type)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(type);
            //byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {
                //返回空
                return null;
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }

        public static int[] BytesToArray(byte[] Bytes, int[] intObj)
        {
            int size = sizeof(int) * intObj.Length;
            int[] Obj = new int[intObj.Length];
            if (size > Bytes.Length)
            {
                return null;
            }
            IntPtr ObjPtr = Marshal.AllocHGlobal(Bytes.Length);
            Marshal.Copy(Bytes, 0, ObjPtr, Bytes.Length);
            Marshal.Copy(ObjPtr, Obj, 0, intObj.Length);
            Marshal.FreeBSTR(ObjPtr);
            return Obj;
        }

        public static float[] BytesToArray(byte[] Bytes, float[] floatObj)
        {
            int size = sizeof(float) * floatObj.Length;
            float[] Obj = new float[floatObj.Length];
            if (size > Bytes.Length)
            {
                return null;
            }
            IntPtr ObjPtr = Marshal.AllocHGlobal(Bytes.Length);
            Marshal.Copy(Bytes, 0, ObjPtr, Bytes.Length);
            Marshal.Copy(ObjPtr, Obj, 0, floatObj.Length);
            Marshal.FreeBSTR(ObjPtr);
            return Obj;
        }

        /// <summary>
        /// 合并文件函数
        /// </summary>
        /// <param name="heb">seg-y文件结构体，引用类型（前加“ref”）</param>
        /// <param name="pianzi">sgy数据偏移量，从每道数据的第pianzi个数据开始合并</param>
        /// <param name="filname">要合并的sgy文件的绝对路径，变长参数</param>
        /// <returns>合并成功返回true，否则返回false</returns>
        public static bool hebing(ref SGY_data heb, int pianzi, params string[] filname)
        {
            short j = 0, ntrp_num = 0, ntrpr_tmp = 0;
            ushort hns_max;
            try
            {
                SGY_data[] fil = new SGY_data[filname.Length];
                foreach (string i in filname)
                {
                    if (Open(i, ref  fil[j]) == true)
                    {
                        ++j;
                    }
                }
                foreach (SGY_data i in fil)
                {
                    ntrp_num += (short)i.head_se.ntrpr;
                }
                hns_max = fil[0].head_se.hns;
                foreach (SGY_data i in fil)
                {
                    hns_max = (hns_max > i.head_se.hns) ? hns_max : i.head_se.hns;
                }
                heb.Head_f = fil[0].Head_f;
                heb.head_se = fil[0].head_se;
                heb.daoju = new SU_data[ntrp_num];
                heb.head_se.ntrpr = heb.head_se.nart = ntrp_num;
                heb.head_se.hns = heb.head_se.nso = hns_max;
                heb.head_se.format = 5;
                for (int i = 0, f = 0; i < heb.head_se.ntrpr; ++i)
                {
                    heb.daoju[i].sgynum = new float[heb.head_se.hns];
                    for (int k = 0; k < heb.head_se.hns; ++k)
                    {
                        do
                        {
                            if (i < (fil[f].head_se.ntrpr + ntrpr_tmp))
                            {
                                if ((k + pianzi) < fil[f].head_se.hns)
                                    heb.daoju[i].sgynum[k] = fil[f].daoju[i - ntrpr_tmp].sgynum[k + pianzi];
                                break;
                            }
                            else
                            {
                                ntrpr_tmp += fil[f].head_se.ntrpr;
                                ++f;
                            }
                        } while (true);
                    }
                    heb.daoju[i].daotou = fil[f].daoju[i - ntrpr_tmp].daotou;
                    heb.daoju[i].daotou.tracl = i;
                    heb.daoju[i].daotou.tracr = i + 1;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 打开seg-y文件
        /// </summary>
        /// <param name="file_name">要打开sgy文件的绝对路径</param>
        /// <param name="read">seg-y文件结构体，保存打开后的sgy文件所有信息，引用类型（前加“ref”）</param>
        /// <returns>打开成功返回true，否则返回false</returns>
        public static bool Open(string file_name, ref SGY_data read)
        {
            try
            {
                if (File.Exists(file_name) == false)
                {
                    MessageBox.Show("文件不存在！！");
                    return false;
                }
                FileStream rs = new FileStream(file_name, FileMode.Open);
                byte[] read_tmp;
                read_tmp = new byte[3200];
                rs.Read(read_tmp, 0, 3200);
                read.Head_f = System.Text.Encoding.ASCII.GetString(read_tmp);
                read.head_se = new Struct_400();
                read.head_se.hunass = new short[170];
                read_tmp = new byte[400];
                IntPtr tmp = Marshal.AllocHGlobal(400);
                rs.Read(read_tmp, 0, 400);
                Marshal.Copy(read_tmp, 0, tmp, 400);
                read.head_se = (Struct_400)Marshal.PtrToStructure(tmp, typeof(Struct_400));
                Marshal.FreeHGlobal(tmp);
                read.daoju = new SU_data[read.head_se.ntrpr];
                for (int i = 0; i < read.head_se.ntrpr; i++)
                {
                    read_tmp = new byte[240];
                    tmp = Marshal.AllocHGlobal(240);
                    rs.Read(read_tmp, 0, 240);
                    Marshal.Copy(read_tmp, 0, tmp, 240);
                    read.daoju[i].daotou = (Struct_240)Marshal.PtrToStructure(tmp, typeof(Struct_240));
                    Marshal.FreeHGlobal(tmp);
                    read_tmp = new byte[read.head_se.hns * 4];
                    tmp = Marshal.AllocHGlobal(read.head_se.hns * 4);
                    read.daoju[i].sgynum = new float[read.head_se.hns];
                    rs.Read(read_tmp, 0, read.head_se.hns * 4);
                    Marshal.Copy(read_tmp, 0, tmp, read.head_se.hns * 4);
                    Marshal.Copy(tmp, read.daoju[i].sgynum, 0, read.head_se.hns);
                    Marshal.FreeHGlobal(tmp);
                }
                rs.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 写入seg-y文件
        /// </summary>
        /// <param name="sgy">要写入的sgy文件结构体</param>
        /// <param name="filename">要保存的绝对路径名</param>
        /// <returns>写入成功返回true，否则返回false</returns>
        public static bool Write(SGY_data sgy, string filename)
        {
            FileStream ws ;
            try
            {
                ws = new FileStream(filename, FileMode.CreateNew);
            }
            catch (IOException)
            {
                DialogResult result =  MessageBox.Show("文件已存在，是否创建？", "警告！", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ws = new FileStream(filename, FileMode.Create);
                }
                else
                {
                    return false;
                }
            }
            ws.Write(Encoding.ASCII.GetBytes(sgy.Head_f), 0, 3200);
            ws.Write(StructToBytes(sgy.head_se), 0, 400);
            for (int i = 0; i < sgy.head_se.ntrpr; i++)
            {
                ws.Write(StructToBytes(sgy.daoju[i].daotou), 0, 240);
                ws.Write(ArrayToBytes(sgy.daoju[i].sgynum), 0, sgy.head_se.hns * 4);
            }
            ws.Close();
            return true;
        }

    }
    
}
