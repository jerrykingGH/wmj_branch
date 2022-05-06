using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class ET_GSMouseData_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ET.GSMouseData);

            field = type.GetField("LastObjectMatched", flag);
            app.RegisterCLRFieldGetter(field, get_LastObjectMatched_0);
            app.RegisterCLRFieldSetter(field, set_LastObjectMatched_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_LastObjectMatched_0, AssignFromStack_LastObjectMatched_0);
            field = type.GetField("LastObjectClicked", flag);
            app.RegisterCLRFieldGetter(field, get_LastObjectClicked_1);
            app.RegisterCLRFieldSetter(field, set_LastObjectClicked_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_LastObjectClicked_1, AssignFromStack_LastObjectClicked_1);
            field = type.GetField("Enable", flag);
            app.RegisterCLRFieldGetter(field, get_Enable_2);
            app.RegisterCLRFieldSetter(field, set_Enable_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_Enable_2, AssignFromStack_Enable_2);


        }



        static object get_LastObjectMatched_0(ref object o)
        {
            return ET.GSMouseData.LastObjectMatched;
        }

        static StackObject* CopyToStack_LastObjectMatched_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GSMouseData.LastObjectMatched;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_LastObjectMatched_0(ref object o, object v)
        {
            ET.GSMouseData.LastObjectMatched = (UnityEngine.GameObject)v;
        }

        static StackObject* AssignFromStack_LastObjectMatched_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.GameObject @LastObjectMatched = (UnityEngine.GameObject)typeof(UnityEngine.GameObject).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ET.GSMouseData.LastObjectMatched = @LastObjectMatched;
            return ptr_of_this_method;
        }

        static object get_LastObjectClicked_1(ref object o)
        {
            return ET.GSMouseData.LastObjectClicked;
        }

        static StackObject* CopyToStack_LastObjectClicked_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GSMouseData.LastObjectClicked;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_LastObjectClicked_1(ref object o, object v)
        {
            ET.GSMouseData.LastObjectClicked = (UnityEngine.GameObject)v;
        }

        static StackObject* AssignFromStack_LastObjectClicked_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            UnityEngine.GameObject @LastObjectClicked = (UnityEngine.GameObject)typeof(UnityEngine.GameObject).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ET.GSMouseData.LastObjectClicked = @LastObjectClicked;
            return ptr_of_this_method;
        }

        static object get_Enable_2(ref object o)
        {
            return ET.GSMouseData.Enable;
        }

        static StackObject* CopyToStack_Enable_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GSMouseData.Enable;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_Enable_2(ref object o, object v)
        {
            ET.GSMouseData.Enable = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_Enable_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @Enable = ptr_of_this_method->Value == 1;
            ET.GSMouseData.Enable = @Enable;
            return ptr_of_this_method;
        }



    }
}
