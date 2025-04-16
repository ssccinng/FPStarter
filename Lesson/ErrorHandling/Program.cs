// See https://aka.ms/new-console-template for more information

using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Prelude;

Console.WriteLine("Hello, World!");
//
// var a = Either<string,int>.Right(1);
// var aa = a.Match(r => 1, l => 1);
//
// int aaa = 1, b = 0;
// var tt = Try(() => aaa / b);
// var tt1 = Try((int a, int b) => a / b); // 用来bind的？
// var ca = tt1.Invoke();
// var t = tt.Invoke();
//
// var asfda = 1;
//
// SType t = SomeMethod(); // 这步可能出错
// DoSth(t);
// var t =  // 这步可能出错
//     try
//     {
//         return SomeMethod();
//     }
//     catch (Exception e)
//     {
//         return e;
//     }
// DoSth(t);
//
//
// //string GetResult(int id)
// //{
// //    var equipment = GetEquipment(id);
// //    if (equipment == null)
// //    {
// //        throw new Exception("设备未找到");
// //    }
// //    var openResult = equipment.Open(); // 这里也可能throw
// //    if (openResult)
// //    {
// //        throw new Exception("设备打开失败");
// //    }
//
// //    var result = equipment.GetResult(); // 这里也可能throw
// //    if (result == null)
// //    {
// //        throw new Exception("设备操作失败");
// //    }
//
// //    var closeResult = equipment.Close(); // 这里也可能throw
// //    if (closeResult)
// //    {
// //        throw new Exception("设备关闭失败");
// //    }
// //    return result;
// //}
//
// //Either<string, string> GetResult(int id)
// //{
// //    return GetEquipment(id)
// //        .ToEither("设备未找到") // 将option转换为Either 如果是None则返回左值
// //        .Bind(EquipTools.Open) // 打开设备
// //        .Bind(EquipTools.GetResult) // 获取结果
// //        .Bind(EquipTools.Close) // 关闭设备 // 中间件！
// //}
//
// public interface Either<L, R>;
//
//     
// public static class Test
// {
//     
//     public static Either<L, R1> Map<L, R, R1>(this Either<L, R> either,
//         Func<R, R1> f) =>
//         either.Match<Either<L, R1>>(
//             Right: r => Right(f(r)),
//             l => Left(l)
//         );
//     public static Either<L, R1> Bind<L,R,R1>(this Either<L, R> either,
//         Func<R, Either<L, R1>> f) =>
//         either.Match<Either<L, R1>>(
//             Right: r => f(r),
//             l => Left(l)
//         );
//     public delegate Result<T> Try<T>();
//
//     public static Result<T> Run<T>(this Try<T> f)
//     {
//         try
//         {
//             return f();
//         }
//         catch (Exception e)
//         {
//             return new(e);
//         }
//     }
// }

