; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


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
@assembly_image_cache_hashes = local_unnamed_addr constant [212 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 56
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 88
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 9
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 83
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 72
	i32 120558881, ; 5: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 72
	i32 134690465, ; 6: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 92
	i32 165246403, ; 7: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 33
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 74
	i32 209399409, ; 9: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 31
	i32 230216969, ; 10: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 50
	i32 232815796, ; 11: System.Web.Services => 0xde07cb4 => 103
	i32 261689757, ; 12: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 36
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 54
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 48
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 23
	i32 321597661, ; 16: System.Numerics => 0x132b30dd => 14
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 52
	i32 441335492, ; 18: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 35
	i32 442521989, ; 19: Xamarin.Essentials => 0x1a605985 => 82
	i32 450948140, ; 20: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 47
	i32 465846621, ; 21: mscorlib => 0x1bc4415d => 8
	i32 469710990, ; 22: System.dll => 0x1bff388e => 13
	i32 476646585, ; 23: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 48
	i32 486930444, ; 24: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 60
	i32 525008092, ; 25: SkiaSharp.dll => 0x1f4afcdc => 11
	i32 526420162, ; 26: System.Transactions.dll => 0x1f6088c2 => 97
	i32 527452488, ; 27: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 92
	i32 605376203, ; 28: System.IO.Compression.FileSystem => 0x24154ecb => 101
	i32 627609679, ; 29: Xamarin.AndroidX.CustomView => 0x2568904f => 41
	i32 639843206, ; 30: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 46
	i32 663517072, ; 31: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 79
	i32 666292255, ; 32: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 28
	i32 690569205, ; 33: System.Xml.Linq.dll => 0x29293ff5 => 18
	i32 691348768, ; 34: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 94
	i32 700284507, ; 35: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 89
	i32 720511267, ; 36: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 93
	i32 775507847, ; 37: System.IO.Compression => 0x2e394f87 => 100
	i32 809851609, ; 38: System.Drawing.Common.dll => 0x30455ad9 => 99
	i32 843511501, ; 39: Xamarin.AndroidX.Print => 0x3246f6cd => 67
	i32 928116545, ; 40: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 88
	i32 955402788, ; 41: Newtonsoft.Json => 0x38f24a24 => 9
	i32 956575887, ; 42: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 93
	i32 967690846, ; 43: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 52
	i32 974778368, ; 44: FormsViewGroup.dll => 0x3a19f000 => 5
	i32 1012816738, ; 45: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 71
	i32 1035644815, ; 46: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 27
	i32 1038267912, ; 47: TouchTracking => 0x3de2b608 => 19
	i32 1042160112, ; 48: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 85
	i32 1052210849, ; 49: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 57
	i32 1084122840, ; 50: Xamarin.Kotlin.StdLib => 0x409e66d8 => 91
	i32 1098259244, ; 51: System => 0x41761b2c => 13
	i32 1175144683, ; 52: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 77
	i32 1178241025, ; 53: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 64
	i32 1204270330, ; 54: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 28
	i32 1241128902, ; 55: TouchTracking.dll => 0x49fa1fc6 => 19
	i32 1264511973, ; 56: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 73
	i32 1267360935, ; 57: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 78
	i32 1275534314, ; 58: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 94
	i32 1285473742, ; 59: TouchTracking.Forms => 0x4c9ec5ce => 21
	i32 1293217323, ; 60: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 43
	i32 1365406463, ; 61: System.ServiceModel.Internals.dll => 0x516272ff => 104
	i32 1376866003, ; 62: Xamarin.AndroidX.SavedState => 0x52114ed3 => 71
	i32 1395857551, ; 63: Xamarin.AndroidX.Media.dll => 0x5333188f => 61
	i32 1406073936, ; 64: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 37
	i32 1447642393, ; 65: TouchTracking.Forms.Droid => 0x56494519 => 22
	i32 1460219004, ; 66: Xamarin.Forms.Xaml => 0x57092c7c => 86
	i32 1462112819, ; 67: System.IO.Compression.dll => 0x57261233 => 100
	i32 1469204771, ; 68: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 26
	i32 1582372066, ; 69: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 42
	i32 1583823701, ; 70: TouchTracking.Droid => 0x5e673b55 => 20
	i32 1592978981, ; 71: System.Runtime.Serialization.dll => 0x5ef2ee25 => 4
	i32 1622152042, ; 72: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 59
	i32 1624863272, ; 73: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 81
	i32 1635184631, ; 74: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 46
	i32 1636350590, ; 75: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 40
	i32 1639515021, ; 76: System.Net.Http.dll => 0x61b9038d => 3
	i32 1651816450, ; 77: PracaInzynierska => 0x6274b802 => 10
	i32 1657153582, ; 78: System.Runtime => 0x62c6282e => 16
	i32 1658241508, ; 79: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 75
	i32 1658251792, ; 80: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 87
	i32 1670060433, ; 81: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 36
	i32 1698840827, ; 82: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 90
	i32 1729485958, ; 83: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 32
	i32 1766324549, ; 84: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 74
	i32 1776026572, ; 85: System.Core.dll => 0x69dc03cc => 12
	i32 1788241197, ; 86: Xamarin.AndroidX.Fragment => 0x6a96652d => 47
	i32 1808609942, ; 87: Xamarin.AndroidX.Loader => 0x6bcd3296 => 59
	i32 1813058853, ; 88: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 91
	i32 1813201214, ; 89: Xamarin.Google.Android.Material => 0x6c13413e => 87
	i32 1818569960, ; 90: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 65
	i32 1834579251, ; 91: PracaInzynierska.dll => 0x6d597533 => 10
	i32 1867746548, ; 92: Xamarin.Essentials.dll => 0x6f538cf4 => 82
	i32 1878053835, ; 93: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 86
	i32 1885316902, ; 94: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 29
	i32 1918325493, ; 95: TouchTracking.Forms.Droid.dll => 0x725752f5 => 22
	i32 1919157823, ; 96: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 62
	i32 1983156543, ; 97: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 90
	i32 2019465201, ; 98: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 57
	i32 2055257422, ; 99: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 53
	i32 2079903147, ; 100: System.Runtime.dll => 0x7bf8cdab => 16
	i32 2090596640, ; 101: System.Numerics.Vectors => 0x7c9bf920 => 15
	i32 2097448633, ; 102: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 49
	i32 2126786730, ; 103: Xamarin.Forms.Platform.Android => 0x7ec430aa => 84
	i32 2201107256, ; 104: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 95
	i32 2201231467, ; 105: System.Net.Http => 0x8334206b => 3
	i32 2217644978, ; 106: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 77
	i32 2244775296, ; 107: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 60
	i32 2256548716, ; 108: Xamarin.AndroidX.MultiDex => 0x8680336c => 62
	i32 2261435625, ; 109: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 51
	i32 2279755925, ; 110: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 69
	i32 2315684594, ; 111: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 24
	i32 2403452196, ; 112: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 45
	i32 2409053734, ; 113: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 66
	i32 2465532216, ; 114: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 35
	i32 2471841756, ; 115: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 116: Java.Interop.dll => 0x93918882 => 6
	i32 2501346920, ; 117: System.Data.DataSetExtensions => 0x95178668 => 98
	i32 2505896520, ; 118: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 56
	i32 2581819634, ; 119: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 78
	i32 2605712449, ; 120: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 95
	i32 2620871830, ; 121: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 40
	i32 2624644809, ; 122: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 44
	i32 2633051222, ; 123: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 54
	i32 2701096212, ; 124: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 75
	i32 2732626843, ; 125: Xamarin.AndroidX.Activity => 0xa2e0939b => 23
	i32 2737747696, ; 126: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 26
	i32 2766581644, ; 127: Xamarin.Forms.Core => 0xa4e6af8c => 83
	i32 2770495804, ; 128: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 89
	i32 2778768386, ; 129: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 80
	i32 2779977773, ; 130: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 70
	i32 2810250172, ; 131: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 37
	i32 2819470561, ; 132: System.Xml.dll => 0xa80db4e1 => 17
	i32 2821294376, ; 133: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 70
	i32 2853208004, ; 134: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 80
	i32 2855708567, ; 135: Xamarin.AndroidX.Transition => 0xaa36a797 => 76
	i32 2903344695, ; 136: System.ComponentModel.Composition => 0xad0d8637 => 102
	i32 2905242038, ; 137: mscorlib.dll => 0xad2a79b6 => 8
	i32 2916838712, ; 138: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 81
	i32 2919462931, ; 139: System.Numerics.Vectors.dll => 0xae037813 => 15
	i32 2921128767, ; 140: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 25
	i32 2978675010, ; 141: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 43
	i32 2996846495, ; 142: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 55
	i32 3016983068, ; 143: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 73
	i32 3024354802, ; 144: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 50
	i32 3044182254, ; 145: FormsViewGroup => 0xb57288ee => 5
	i32 3057625584, ; 146: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 63
	i32 3111772706, ; 147: System.Runtime.Serialization => 0xb979e222 => 4
	i32 3204380047, ; 148: System.Data.dll => 0xbefef58f => 96
	i32 3211777861, ; 149: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 42
	i32 3218075837, ; 150: TouchTracking.Forms.dll => 0xbfcff0bd => 21
	i32 3220365878, ; 151: System.Threading => 0xbff2e236 => 2
	i32 3247949154, ; 152: Mono.Security => 0xc197c562 => 105
	i32 3258312781, ; 153: Xamarin.AndroidX.CardView => 0xc235e84d => 32
	i32 3267021929, ; 154: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 30
	i32 3317135071, ; 155: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 41
	i32 3317144872, ; 156: System.Data => 0xc5b79d28 => 96
	i32 3340387945, ; 157: SkiaSharp => 0xc71a4669 => 11
	i32 3340431453, ; 158: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 29
	i32 3345895724, ; 159: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 68
	i32 3346324047, ; 160: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 64
	i32 3353484488, ; 161: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 49
	i32 3362522851, ; 162: Xamarin.AndroidX.Core => 0xc86c06e3 => 39
	i32 3366347497, ; 163: Java.Interop => 0xc8a662e9 => 6
	i32 3374999561, ; 164: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 69
	i32 3404865022, ; 165: System.ServiceModel.Internals => 0xcaf21dfe => 104
	i32 3429136800, ; 166: System.Xml => 0xcc6479a0 => 17
	i32 3430777524, ; 167: netstandard => 0xcc7d82b4 => 1
	i32 3441283291, ; 168: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 44
	i32 3441839626, ; 169: PracaInzynierska.Android => 0xcd264e0a => 0
	i32 3476120550, ; 170: Mono.Android => 0xcf3163e6 => 7
	i32 3486566296, ; 171: System.Transactions => 0xcfd0c798 => 97
	i32 3493954962, ; 172: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 34
	i32 3501239056, ; 173: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 30
	i32 3509114376, ; 174: System.Xml.Linq => 0xd128d608 => 18
	i32 3536029504, ; 175: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 84
	i32 3567349600, ; 176: System.ComponentModel.Composition.dll => 0xd4a16f60 => 102
	i32 3582459313, ; 177: PracaInzynierska.Android.dll => 0xd587fdb1 => 0
	i32 3618140916, ; 178: Xamarin.AndroidX.Preference => 0xd7a872f4 => 66
	i32 3627220390, ; 179: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 67
	i32 3632359727, ; 180: Xamarin.Forms.Platform => 0xd881692f => 85
	i32 3633644679, ; 181: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 25
	i32 3641597786, ; 182: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 53
	i32 3672681054, ; 183: Mono.Android.dll => 0xdae8aa5e => 7
	i32 3676310014, ; 184: System.Web.Services.dll => 0xdb2009fe => 103
	i32 3682565725, ; 185: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 31
	i32 3684561358, ; 186: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 34
	i32 3689375977, ; 187: System.Drawing.Common => 0xdbe768e9 => 99
	i32 3706696989, ; 188: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 38
	i32 3718780102, ; 189: Xamarin.AndroidX.Annotation => 0xdda814c6 => 24
	i32 3724971120, ; 190: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 63
	i32 3758932259, ; 191: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 51
	i32 3786282454, ; 192: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 33
	i32 3822602673, ; 193: Xamarin.AndroidX.Media => 0xe3d849b1 => 61
	i32 3829621856, ; 194: System.Numerics.dll => 0xe4436460 => 14
	i32 3885922214, ; 195: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 76
	i32 3888767677, ; 196: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 68
	i32 3896760992, ; 197: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 39
	i32 3920810846, ; 198: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 101
	i32 3921031405, ; 199: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 79
	i32 3931092270, ; 200: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 65
	i32 3945713374, ; 201: System.Data.DataSetExtensions.dll => 0xeb2ecede => 98
	i32 3955647286, ; 202: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 27
	i32 3959773229, ; 203: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 55
	i32 3986687458, ; 204: TouchTracking.Droid.dll => 0xeda005e2 => 20
	i32 4073602200, ; 205: System.Threading.dll => 0xf2ce3c98 => 2
	i32 4101593132, ; 206: Xamarin.AndroidX.Emoji2 => 0xf479582c => 45
	i32 4105002889, ; 207: Mono.Security.dll => 0xf4ad5f89 => 105
	i32 4151237749, ; 208: System.Core => 0xf76edc75 => 12
	i32 4182413190, ; 209: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 58
	i32 4256097574, ; 210: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 38
	i32 4292120959 ; 211: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 58
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [212 x i32] [
	i32 56, i32 88, i32 9, i32 83, i32 72, i32 72, i32 92, i32 33, ; 0..7
	i32 74, i32 31, i32 50, i32 103, i32 36, i32 54, i32 48, i32 23, ; 8..15
	i32 14, i32 52, i32 35, i32 82, i32 47, i32 8, i32 13, i32 48, ; 16..23
	i32 60, i32 11, i32 97, i32 92, i32 101, i32 41, i32 46, i32 79, ; 24..31
	i32 28, i32 18, i32 94, i32 89, i32 93, i32 100, i32 99, i32 67, ; 32..39
	i32 88, i32 9, i32 93, i32 52, i32 5, i32 71, i32 27, i32 19, ; 40..47
	i32 85, i32 57, i32 91, i32 13, i32 77, i32 64, i32 28, i32 19, ; 48..55
	i32 73, i32 78, i32 94, i32 21, i32 43, i32 104, i32 71, i32 61, ; 56..63
	i32 37, i32 22, i32 86, i32 100, i32 26, i32 42, i32 20, i32 4, ; 64..71
	i32 59, i32 81, i32 46, i32 40, i32 3, i32 10, i32 16, i32 75, ; 72..79
	i32 87, i32 36, i32 90, i32 32, i32 74, i32 12, i32 47, i32 59, ; 80..87
	i32 91, i32 87, i32 65, i32 10, i32 82, i32 86, i32 29, i32 22, ; 88..95
	i32 62, i32 90, i32 57, i32 53, i32 16, i32 15, i32 49, i32 84, ; 96..103
	i32 95, i32 3, i32 77, i32 60, i32 62, i32 51, i32 69, i32 24, ; 104..111
	i32 45, i32 66, i32 35, i32 1, i32 6, i32 98, i32 56, i32 78, ; 112..119
	i32 95, i32 40, i32 44, i32 54, i32 75, i32 23, i32 26, i32 83, ; 120..127
	i32 89, i32 80, i32 70, i32 37, i32 17, i32 70, i32 80, i32 76, ; 128..135
	i32 102, i32 8, i32 81, i32 15, i32 25, i32 43, i32 55, i32 73, ; 136..143
	i32 50, i32 5, i32 63, i32 4, i32 96, i32 42, i32 21, i32 2, ; 144..151
	i32 105, i32 32, i32 30, i32 41, i32 96, i32 11, i32 29, i32 68, ; 152..159
	i32 64, i32 49, i32 39, i32 6, i32 69, i32 104, i32 17, i32 1, ; 160..167
	i32 44, i32 0, i32 7, i32 97, i32 34, i32 30, i32 18, i32 84, ; 168..175
	i32 102, i32 0, i32 66, i32 67, i32 85, i32 25, i32 53, i32 7, ; 176..183
	i32 103, i32 31, i32 34, i32 99, i32 38, i32 24, i32 63, i32 51, ; 184..191
	i32 33, i32 61, i32 14, i32 76, i32 68, i32 39, i32 101, i32 79, ; 192..199
	i32 65, i32 98, i32 27, i32 55, i32 20, i32 2, i32 45, i32 105, ; 200..207
	i32 12, i32 58, i32 38, i32 58 ; 208..211
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
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


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
