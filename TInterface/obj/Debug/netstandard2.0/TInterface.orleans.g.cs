// <auto-generated />
#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 618
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::Orleans.Metadata.FeaturePopulatorAttribute(typeof (OrleansGeneratedCode.OrleansCodeGen451ad3e84dFeaturePopulator))]
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute(@"Orleans-CodeGenerator", @"2.0.0.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute(@"TInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace TInterface
{
    using global::Orleans;
    using global::System.Reflection;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute(@"Orleans-CodeGenerator", @"2.0.0.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::TInterface.ITest))]
    internal class OrleansCodeGenTestReference : global::Orleans.Runtime.GrainReference, global::TInterface.ITest
    {
        protected OrleansCodeGenTestReference(global::Orleans.Runtime.GrainReference other): base (other)
        {
        }

        OrleansCodeGenTestReference(global::Orleans.Runtime.GrainReference other, global::Orleans.CodeGeneration.InvokeMethodOptions invokeMethodOptions): base (other, invokeMethodOptions)
        {
        }

        protected OrleansCodeGenTestReference(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context): base (info, context)
        {
        }

        public override global::System.Int32 InterfaceId
        {
            get
            {
                return -480880784;
            }
        }

        public override global::System.UInt16 InterfaceVersion
        {
            get
            {
                return 1;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return @"global::TInterface.ITest";
            }
        }

        public override global::System.Boolean IsCompatible(global::System.Int32 interfaceId)
        {
            return interfaceId == -480880784;
        }

        public override global::System.String GetMethodName(global::System.Int32 interfaceId, global::System.Int32 methodId)
        {
            switch (interfaceId)
            {
                case -480880784:
                    switch (methodId)
                    {
                        case -1256896228:
                            return @"GetName";
                        default:
                            throw new global::System.NotImplementedException(@"interfaceId=" + -480880784 + @",methodId=" + methodId);
                    }

                default:
                    throw new global::System.NotImplementedException(@"interfaceId=" + interfaceId);
            }
        }

        public global::System.Threading.Tasks.Task<global::System.String> GetName()
        {
            return base.InvokeMethodAsync<global::System.String>(-1256896228, null);
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute(@"Orleans-CodeGenerator", @"2.0.0.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute(typeof (global::TInterface.ITest), -480880784), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenTestMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public async global::System.Threading.Tasks.Task<global::System.Object> Invoke(global::Orleans.Runtime.IAddressable grain, global::Orleans.CodeGeneration.InvokeMethodRequest request)
        {
            global::System.Int32 interfaceId = request.InterfaceId;
            global::System.Int32 methodId = request.MethodId;
            global::System.Object[] arguments = request.Arguments;
            if (grain == null)
                throw new global::System.ArgumentNullException(@"grain");
            switch (interfaceId)
            {
                case -480880784:
                    switch (methodId)
                    {
                        case -1256896228:
                            return await ((global::TInterface.ITest)grain).GetName();
                        default:
                            throw new global::System.NotImplementedException(@"interfaceId=" + -480880784 + @",methodId=" + methodId);
                    }

                default:
                    throw new global::System.NotImplementedException(@"interfaceId=" + interfaceId);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return -480880784;
            }
        }

        public global::System.UInt16 InterfaceVersion
        {
            get
            {
                return 1;
            }
        }
    }
}

namespace OrleansGeneratedCode3298B51F
{
    using global::Orleans;
    using global::System.Reflection;
}

namespace OrleansGeneratedCode
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute(@"Orleans-CodeGenerator", @"2.0.0.0")]
    internal sealed class OrleansCodeGen451ad3e84dFeaturePopulator : global::Orleans.Metadata.IFeaturePopulator<global::Orleans.Metadata.GrainInterfaceFeature>, global::Orleans.Metadata.IFeaturePopulator<global::Orleans.Metadata.GrainClassFeature>, global::Orleans.Metadata.IFeaturePopulator<global::Orleans.Serialization.SerializerFeature>
    {
        public void Populate(global::Orleans.Metadata.GrainInterfaceFeature feature)
        {
            feature.Interfaces.Add(new global::Orleans.Metadata.GrainInterfaceMetadata(typeof (global::TInterface.ITest), typeof (TInterface.OrleansCodeGenTestReference), typeof (TInterface.OrleansCodeGenTestMethodInvoker), -480880784));
        }

        public void Populate(global::Orleans.Metadata.GrainClassFeature feature)
        {
        }

        public void Populate(global::Orleans.Serialization.SerializerFeature feature)
        {
            feature.AddKnownType(@"TInterface.ITest,TInterface", @"TInterface.ITest");
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif