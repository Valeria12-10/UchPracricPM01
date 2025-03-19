; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [246 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 62
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 93
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 86
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 76
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 76
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 43
	i32 166922606, ; 6: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 27
	i32 172012715, ; 7: FastAndroidCamera.dll => 0xa40b4ab => 5
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 77
	i32 209399409, ; 9: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 41
	i32 212497893, ; 10: Xamarin.Forms.Maps.Android => 0xcaa75e5 => 87
	i32 219130465, ; 11: Xamarin.Android.Support.v4 => 0xd0faa61 => 32
	i32 220171995, ; 12: System.Diagnostics.Debug => 0xd1f8edb => 116
	i32 230216969, ; 13: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 57
	i32 231814094, ; 14: System.Globalization => 0xdd133ce => 122
	i32 232815796, ; 15: System.Web.Services => 0xde07cb4 => 110
	i32 261689757, ; 16: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 46
	i32 278686392, ; 17: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 61
	i32 280482487, ; 18: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 55
	i32 318968648, ; 19: Xamarin.AndroidX.Activity.dll => 0x13031348 => 33
	i32 319314094, ; 20: Xamarin.Forms.Maps => 0x130858ae => 88
	i32 321597661, ; 21: System.Numerics => 0x132b30dd => 19
	i32 334355562, ; 22: ZXing.Net.Mobile.Forms.dll => 0x13eddc6a => 100
	i32 342366114, ; 23: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 59
	i32 347068432, ; 24: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 13
	i32 385762202, ; 25: System.Memory.dll => 0x16fe439a => 18
	i32 389971796, ; 26: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 28
	i32 441335492, ; 27: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 45
	i32 442521989, ; 28: Xamarin.Essentials => 0x1a605985 => 85
	i32 442565967, ; 29: System.Collections => 0x1a61054f => 114
	i32 450948140, ; 30: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 54
	i32 465846621, ; 31: mscorlib => 0x1bc4415d => 9
	i32 469710990, ; 32: System.dll => 0x1bff388e => 17
	i32 476646585, ; 33: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 55
	i32 486930444, ; 34: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 66
	i32 498788369, ; 35: System.ObjectModel => 0x1dbae811 => 117
	i32 514659665, ; 36: Xamarin.Android.Support.Compat => 0x1ead1551 => 27
	i32 526420162, ; 37: System.Transactions.dll => 0x1f6088c2 => 104
	i32 545304856, ; 38: System.Runtime.Extensions => 0x2080b118 => 115
	i32 605376203, ; 39: System.IO.Compression.FileSystem => 0x24154ecb => 108
	i32 627609679, ; 40: Xamarin.AndroidX.CustomView => 0x2568904f => 50
	i32 663517072, ; 41: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 82
	i32 666292255, ; 42: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 38
	i32 690569205, ; 43: System.Xml.Linq.dll => 0x29293ff5 => 24
	i32 692692150, ; 44: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 26
	i32 748832960, ; 45: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 11
	i32 775507847, ; 46: System.IO.Compression => 0x2e394f87 => 107
	i32 809851609, ; 47: System.Drawing.Common.dll => 0x30455ad9 => 106
	i32 843511501, ; 48: Xamarin.AndroidX.Print => 0x3246f6cd => 73
	i32 877678880, ; 49: System.Globalization.dll => 0x34505120 => 122
	i32 882883187, ; 50: Xamarin.Android.Support.v4.dll => 0x349fba73 => 32
	i32 928116545, ; 51: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 93
	i32 954320159, ; 52: ZXing.Net.Mobile.Forms => 0x38e1c51f => 100
	i32 958213972, ; 53: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 31
	i32 967690846, ; 54: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 59
	i32 974778368, ; 55: FormsViewGroup.dll => 0x3a19f000 => 6
	i32 992768348, ; 56: System.Collections.dll => 0x3b2c715c => 114
	i32 1012816738, ; 57: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 75
	i32 1035644815, ; 58: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 37
	i32 1042160112, ; 59: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 90
	i32 1052210849, ; 60: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 63
	i32 1098259244, ; 61: System => 0x41761b2c => 17
	i32 1134191450, ; 62: ZXingNetMobile.dll => 0x439a635a => 102
	i32 1175144683, ; 63: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 80
	i32 1178241025, ; 64: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 70
	i32 1204270330, ; 65: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 38
	i32 1267360935, ; 66: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 81
	i32 1292207520, ; 67: SQLitePCLRaw.core.dll => 0x4d0585a0 => 12
	i32 1293217323, ; 68: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 52
	i32 1364015309, ; 69: System.IO => 0x514d38cd => 120
	i32 1365406463, ; 70: System.ServiceModel.Internals.dll => 0x516272ff => 111
	i32 1376866003, ; 71: Xamarin.AndroidX.SavedState => 0x52114ed3 => 75
	i32 1395857551, ; 72: Xamarin.AndroidX.Media.dll => 0x5333188f => 67
	i32 1406073936, ; 73: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 47
	i32 1411638395, ; 74: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 21
	i32 1445445088, ; 75: Xamarin.Android.Support.Fragment => 0x5627bde0 => 30
	i32 1457743152, ; 76: System.Runtime.Extensions.dll => 0x56e36530 => 115
	i32 1460219004, ; 77: Xamarin.Forms.Xaml => 0x57092c7c => 91
	i32 1462112819, ; 78: System.IO.Compression.dll => 0x57261233 => 107
	i32 1469204771, ; 79: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 36
	i32 1530663695, ; 80: Xamarin.Forms.Maps.dll => 0x5b3c130f => 88
	i32 1543031311, ; 81: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 121
	i32 1571005899, ; 82: zxing.portable => 0x5da3a5cb => 101
	i32 1574652163, ; 83: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 29
	i32 1582372066, ; 84: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 51
	i32 1592978981, ; 85: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1622152042, ; 86: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 65
	i32 1624863272, ; 87: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 84
	i32 1636350590, ; 88: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 49
	i32 1639515021, ; 89: System.Net.Http.dll => 0x61b9038d => 2
	i32 1639986890, ; 90: System.Text.RegularExpressions => 0x61c036ca => 121
	i32 1657153582, ; 91: System.Runtime => 0x62c6282e => 22
	i32 1658241508, ; 92: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 78
	i32 1658251792, ; 93: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 92
	i32 1670060433, ; 94: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 46
	i32 1701541528, ; 95: System.Diagnostics.Debug.dll => 0x656b7698 => 116
	i32 1711441057, ; 96: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 13
	i32 1729485958, ; 97: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 42
	i32 1766324549, ; 98: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 77
	i32 1776026572, ; 99: System.Core.dll => 0x69dc03cc => 16
	i32 1788241197, ; 100: Xamarin.AndroidX.Fragment => 0x6a96652d => 54
	i32 1808609942, ; 101: Xamarin.AndroidX.Loader => 0x6bcd3296 => 65
	i32 1813201214, ; 102: Xamarin.Google.Android.Material => 0x6c13413e => 92
	i32 1818569960, ; 103: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 71
	i32 1867746548, ; 104: Xamarin.Essentials.dll => 0x6f538cf4 => 85
	i32 1878053835, ; 105: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 91
	i32 1881862856, ; 106: Xamarin.Forms.Maps.Android.dll => 0x702af2c8 => 87
	i32 1885316902, ; 107: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 39
	i32 1904184254, ; 108: FastAndroidCamera => 0x717f8bbe => 5
	i32 1908813208, ; 109: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 95
	i32 1919157823, ; 110: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 68
	i32 1970135796, ; 111: WarehouseMob.Android.dll => 0x756de2f4 => 0
	i32 2011961780, ; 112: System.Buffers.dll => 0x77ec19b4 => 15
	i32 2019465201, ; 113: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 63
	i32 2055257422, ; 114: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 60
	i32 2079903147, ; 115: System.Runtime.dll => 0x7bf8cdab => 22
	i32 2090596640, ; 116: System.Numerics.Vectors => 0x7c9bf920 => 20
	i32 2097448633, ; 117: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 56
	i32 2103459038, ; 118: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 14
	i32 2126786730, ; 119: Xamarin.Forms.Platform.Android => 0x7ec430aa => 89
	i32 2129483829, ; 120: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 94
	i32 2166116741, ; 121: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 29
	i32 2193016926, ; 122: System.ObjectModel.dll => 0x82b6c85e => 117
	i32 2201231467, ; 123: System.Net.Http => 0x8334206b => 2
	i32 2217644978, ; 124: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 80
	i32 2244775296, ; 125: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 66
	i32 2256548716, ; 126: Xamarin.AndroidX.MultiDex => 0x8680336c => 68
	i32 2261435625, ; 127: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 58
	i32 2279755925, ; 128: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 74
	i32 2315684594, ; 129: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 34
	i32 2329204181, ; 130: zxing.portable.dll => 0x8ad4d5d5 => 101
	i32 2330457430, ; 131: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 28
	i32 2341995103, ; 132: ZXingNetMobile => 0x8b98025f => 102
	i32 2373288475, ; 133: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 30
	i32 2409053734, ; 134: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 72
	i32 2431243866, ; 135: ZXing.Net.Mobile.Core.dll => 0x90e9d65a => 98
	i32 2454381212, ; 136: WarehouseMob => 0x924ae29c => 25
	i32 2454642406, ; 137: System.Text.Encoding.dll => 0x924edee6 => 119
	i32 2465273461, ; 138: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 11
	i32 2465532216, ; 139: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 45
	i32 2471841756, ; 140: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 141: Java.Interop.dll => 0x93918882 => 7
	i32 2482213323, ; 142: ZXing.Net.Mobile.Forms.Android => 0x93f391cb => 99
	i32 2501346920, ; 143: System.Data.DataSetExtensions => 0x95178668 => 105
	i32 2505896520, ; 144: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 62
	i32 2581819634, ; 145: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 81
	i32 2620871830, ; 146: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 49
	i32 2624644809, ; 147: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 53
	i32 2633051222, ; 148: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 61
	i32 2693849962, ; 149: System.IO.dll => 0xa090e36a => 120
	i32 2701096212, ; 150: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 78
	i32 2715334215, ; 151: System.Threading.Tasks.dll => 0xa1d8b647 => 113
	i32 2732626843, ; 152: Xamarin.AndroidX.Activity => 0xa2e0939b => 33
	i32 2737747696, ; 153: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 36
	i32 2766581644, ; 154: Xamarin.Forms.Core => 0xa4e6af8c => 86
	i32 2778768386, ; 155: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 83
	i32 2810250172, ; 156: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 47
	i32 2819470561, ; 157: System.Xml.dll => 0xa80db4e1 => 23
	i32 2847418871, ; 158: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 94
	i32 2853208004, ; 159: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 83
	i32 2855708567, ; 160: Xamarin.AndroidX.Transition => 0xaa36a797 => 79
	i32 2903344695, ; 161: System.ComponentModel.Composition => 0xad0d8637 => 109
	i32 2905242038, ; 162: mscorlib.dll => 0xad2a79b6 => 9
	i32 2916838712, ; 163: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 84
	i32 2919462931, ; 164: System.Numerics.Vectors.dll => 0xae037813 => 20
	i32 2921128767, ; 165: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 35
	i32 2970759306, ; 166: BCrypt.Net-Next.dll => 0xb112308a => 4
	i32 2978675010, ; 167: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 52
	i32 3017076677, ; 168: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 96
	i32 3024354802, ; 169: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 57
	i32 3044182254, ; 170: FormsViewGroup => 0xb57288ee => 6
	i32 3057625584, ; 171: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 69
	i32 3058099980, ; 172: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 97
	i32 3075834255, ; 173: System.Threading.Tasks => 0xb755818f => 113
	i32 3092211740, ; 174: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 31
	i32 3111772706, ; 175: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3204380047, ; 176: System.Data.dll => 0xbefef58f => 103
	i32 3211777861, ; 177: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 51
	i32 3220365878, ; 178: System.Threading => 0xbff2e236 => 118
	i32 3230466174, ; 179: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 95
	i32 3247949154, ; 180: Mono.Security => 0xc197c562 => 112
	i32 3258312781, ; 181: Xamarin.AndroidX.CardView => 0xc235e84d => 42
	i32 3267021929, ; 182: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 40
	i32 3286872994, ; 183: SQLite-net.dll => 0xc3e9b3a2 => 10
	i32 3299363146, ; 184: System.Text.Encoding => 0xc4a8494a => 119
	i32 3317135071, ; 185: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 50
	i32 3317144872, ; 186: System.Data => 0xc5b79d28 => 103
	i32 3340431453, ; 187: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 39
	i32 3346324047, ; 188: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 70
	i32 3352104953, ; 189: WarehouseMob.dll => 0xc7cd0ff9 => 25
	i32 3353484488, ; 190: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 56
	i32 3360279109, ; 191: SQLitePCLRaw.core => 0xc849ca45 => 12
	i32 3362522851, ; 192: Xamarin.AndroidX.Core => 0xc86c06e3 => 48
	i32 3366347497, ; 193: Java.Interop => 0xc8a662e9 => 7
	i32 3374999561, ; 194: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 74
	i32 3395150330, ; 195: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 21
	i32 3404865022, ; 196: System.ServiceModel.Internals => 0xcaf21dfe => 111
	i32 3429136800, ; 197: System.Xml => 0xcc6479a0 => 23
	i32 3430777524, ; 198: netstandard => 0xcc7d82b4 => 1
	i32 3439690031, ; 199: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 26
	i32 3441283291, ; 200: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 53
	i32 3472012038, ; 201: BCrypt.Net-Next => 0xcef2b306 => 4
	i32 3476120550, ; 202: Mono.Android => 0xcf3163e6 => 8
	i32 3486566296, ; 203: System.Transactions => 0xcfd0c798 => 104
	i32 3493954962, ; 204: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 44
	i32 3501239056, ; 205: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 40
	i32 3509114376, ; 206: System.Xml.Linq => 0xd128d608 => 24
	i32 3536029504, ; 207: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 89
	i32 3567349600, ; 208: System.ComponentModel.Composition.dll => 0xd4a16f60 => 109
	i32 3618140916, ; 209: Xamarin.AndroidX.Preference => 0xd7a872f4 => 72
	i32 3627220390, ; 210: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 73
	i32 3632359727, ; 211: Xamarin.Forms.Platform => 0xd881692f => 90
	i32 3633644679, ; 212: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 35
	i32 3641597786, ; 213: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 60
	i32 3672681054, ; 214: Mono.Android.dll => 0xdae8aa5e => 8
	i32 3676310014, ; 215: System.Web.Services.dll => 0xdb2009fe => 110
	i32 3682565725, ; 216: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 41
	i32 3684561358, ; 217: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 44
	i32 3689375977, ; 218: System.Drawing.Common => 0xdbe768e9 => 106
	i32 3718780102, ; 219: Xamarin.AndroidX.Annotation => 0xdda814c6 => 34
	i32 3724971120, ; 220: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 69
	i32 3754567612, ; 221: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 14
	i32 3758932259, ; 222: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 58
	i32 3786282454, ; 223: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 43
	i32 3822602673, ; 224: Xamarin.AndroidX.Media => 0xe3d849b1 => 67
	i32 3829621856, ; 225: System.Numerics.dll => 0xe4436460 => 19
	i32 3847036339, ; 226: ZXing.Net.Mobile.Forms.Android.dll => 0xe54d1db3 => 99
	i32 3857872905, ; 227: WarehouseMob.Android => 0xe5f27809 => 0
	i32 3876362041, ; 228: SQLite-net => 0xe70c9739 => 10
	i32 3885922214, ; 229: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 79
	i32 3896760992, ; 230: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 48
	i32 3920810846, ; 231: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 108
	i32 3921031405, ; 232: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 82
	i32 3931092270, ; 233: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 71
	i32 3945713374, ; 234: System.Data.DataSetExtensions.dll => 0xeb2ecede => 105
	i32 3955647286, ; 235: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 37
	i32 3970018735, ; 236: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 97
	i32 4025784931, ; 237: System.Memory => 0xeff49a63 => 18
	i32 4073602200, ; 238: System.Threading.dll => 0xf2ce3c98 => 118
	i32 4105002889, ; 239: Mono.Security.dll => 0xf4ad5f89 => 112
	i32 4151237749, ; 240: System.Core => 0xf76edc75 => 16
	i32 4182413190, ; 241: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 64
	i32 4186595366, ; 242: ZXing.Net.Mobile.Core => 0xf98a6026 => 98
	i32 4260525087, ; 243: System.Buffers => 0xfdf2741f => 15
	i32 4278134329, ; 244: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 96
	i32 4292120959 ; 245: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 64
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [246 x i32] [
	i32 62, i32 93, i32 86, i32 76, i32 76, i32 43, i32 27, i32 5, ; 0..7
	i32 77, i32 41, i32 87, i32 32, i32 116, i32 57, i32 122, i32 110, ; 8..15
	i32 46, i32 61, i32 55, i32 33, i32 88, i32 19, i32 100, i32 59, ; 16..23
	i32 13, i32 18, i32 28, i32 45, i32 85, i32 114, i32 54, i32 9, ; 24..31
	i32 17, i32 55, i32 66, i32 117, i32 27, i32 104, i32 115, i32 108, ; 32..39
	i32 50, i32 82, i32 38, i32 24, i32 26, i32 11, i32 107, i32 106, ; 40..47
	i32 73, i32 122, i32 32, i32 93, i32 100, i32 31, i32 59, i32 6, ; 48..55
	i32 114, i32 75, i32 37, i32 90, i32 63, i32 17, i32 102, i32 80, ; 56..63
	i32 70, i32 38, i32 81, i32 12, i32 52, i32 120, i32 111, i32 75, ; 64..71
	i32 67, i32 47, i32 21, i32 30, i32 115, i32 91, i32 107, i32 36, ; 72..79
	i32 88, i32 121, i32 101, i32 29, i32 51, i32 3, i32 65, i32 84, ; 80..87
	i32 49, i32 2, i32 121, i32 22, i32 78, i32 92, i32 46, i32 116, ; 88..95
	i32 13, i32 42, i32 77, i32 16, i32 54, i32 65, i32 92, i32 71, ; 96..103
	i32 85, i32 91, i32 87, i32 39, i32 5, i32 95, i32 68, i32 0, ; 104..111
	i32 15, i32 63, i32 60, i32 22, i32 20, i32 56, i32 14, i32 89, ; 112..119
	i32 94, i32 29, i32 117, i32 2, i32 80, i32 66, i32 68, i32 58, ; 120..127
	i32 74, i32 34, i32 101, i32 28, i32 102, i32 30, i32 72, i32 98, ; 128..135
	i32 25, i32 119, i32 11, i32 45, i32 1, i32 7, i32 99, i32 105, ; 136..143
	i32 62, i32 81, i32 49, i32 53, i32 61, i32 120, i32 78, i32 113, ; 144..151
	i32 33, i32 36, i32 86, i32 83, i32 47, i32 23, i32 94, i32 83, ; 152..159
	i32 79, i32 109, i32 9, i32 84, i32 20, i32 35, i32 4, i32 52, ; 160..167
	i32 96, i32 57, i32 6, i32 69, i32 97, i32 113, i32 31, i32 3, ; 168..175
	i32 103, i32 51, i32 118, i32 95, i32 112, i32 42, i32 40, i32 10, ; 176..183
	i32 119, i32 50, i32 103, i32 39, i32 70, i32 25, i32 56, i32 12, ; 184..191
	i32 48, i32 7, i32 74, i32 21, i32 111, i32 23, i32 1, i32 26, ; 192..199
	i32 53, i32 4, i32 8, i32 104, i32 44, i32 40, i32 24, i32 89, ; 200..207
	i32 109, i32 72, i32 73, i32 90, i32 35, i32 60, i32 8, i32 110, ; 208..215
	i32 41, i32 44, i32 106, i32 34, i32 69, i32 14, i32 58, i32 43, ; 216..223
	i32 67, i32 19, i32 99, i32 0, i32 10, i32 79, i32 48, i32 108, ; 224..231
	i32 82, i32 71, i32 105, i32 37, i32 97, i32 18, i32 118, i32 112, ; 232..239
	i32 16, i32 64, i32 98, i32 15, i32 96, i32 64 ; 240..245
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
