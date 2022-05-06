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
    unsafe class ET_GSMouseEventTrigger_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ET.GSMouseEventTrigger);
            args = new Type[]{typeof(System.String), typeof(System.Action)};
            method = type.GetMethod("AddEvent", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, AddEvent_0);

            field = type.GetField("Limit", flag);
            app.RegisterCLRFieldGetter(field, get_Limit_0);
            app.RegisterCLRFieldSetter(field, set_Limit_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Limit_0, AssignFromStack_Limit_0);


        }


        static StackObject* AddEvent_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Action @handle = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)8);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.String @mouseEventType = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ET.GSMouseEventTrigger instance_of_this_method = (ET.GSMouseEventTrigger)typeof(ET.GSMouseEventTrigger).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.AddEvent(@mouseEventType, @handle);

            return __ret;
        }


        static object get_Limit_0(ref object o)
        {
            return ((ET.GSMouseEventTrigger)o).Limit;
        }

        static StackObject* CopyToStack_Limit_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((ET.GSMouseEventTrigger)o).Limit;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_Limit_0(ref object o, object v)
        {
            ((ET.GSMouseEventTrigger)o).Limit = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_Limit_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @Limit = ptr_of_this_method->Value == 1;
            ((ET.GSMouseEventTrigger)o).Limit = @Limit;
            return ptr_of_this_method;
        }



    }
}
