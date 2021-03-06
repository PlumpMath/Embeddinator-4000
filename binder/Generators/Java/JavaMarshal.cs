﻿using CppSharp.AST;

namespace MonoEmbeddinator4000.Generators
{
    public class JavaMarshalPrinter : CMarshalPrinter
    {
        public JavaMarshalPrinter(MarshalContext marshalContext)
            : base(marshalContext)
        {
        }
    }

    public class JavaMarshalManagedToNative : JavaMarshalPrinter
    {
        public JavaMarshalManagedToNative(MarshalContext marshalContext)
            : base(marshalContext)
        {
        }

        public override bool VisitManagedArrayType(ManagedArrayType array,
            TypeQualifiers quals)
        {
            Context.Return.Write("null");
            return true;
        }

        public override bool VisitClassDecl(Class @class)
        {
            Context.Return.Write($"{Context.ArgName}.__object");
            return true;
        }

        public override bool VisitEnumDecl(Enumeration @enum)
        {
            Context.Return.Write(Context.ArgName);
            return true;
        }

        public override bool VisitPrimitiveType(PrimitiveType type,
            TypeQualifiers quals)
        {
            Context.Return.Write(Context.ArgName);
            return true;
        }
    }

    public class JavaMarshalNativeToManaged : JavaMarshalPrinter
    {
        public JavaMarshalNativeToManaged (MarshalContext marshalContext)
            : base(marshalContext)
        {
        }

        public override bool VisitManagedArrayType(ManagedArrayType array,
            TypeQualifiers quals)
        {
            Context.Return.Write("null");
            return true;
        }

        public override bool VisitClassDecl(Class @class)
        {
            Context.Return.Write("null");
            return true;
        }

        public override bool VisitEnumDecl(Enumeration @enum)
        {
            Context.Return.Write(Context.ReturnVarName);
            return true;
        }

        public override bool VisitPrimitiveType(PrimitiveType type,
            TypeQualifiers quals)
        {
            Context.Return.Write(Context.ReturnVarName);
            return true;
        }
    }
}
