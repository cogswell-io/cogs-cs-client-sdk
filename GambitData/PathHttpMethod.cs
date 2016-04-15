namespace GambitData
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Threading;


    /// <summary>
    /// The path http method.
    /// </summary>
    [Serializable]
    [DataContract(Name = "PathHttpMethod")]
    [Export(typeof(IPathHttpMethod))]
    public class PathHttpMethod : IPathHttpMethod
    {
        /// <summary>
        /// The list 2 proxy.
        /// </summary>
        IList<IParameter> list2Proxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathHttpMethod"/> class.
        /// </summary>
        public PathHttpMethod()
        {
            RealParametersList = new List<Parameter>();
            MyResponses = new Responses();
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the real parameters list.
        /// </summary>
        [DataMember(Name = "parameters")]
        private List<Parameter> RealParametersList { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the my responses.
        /// </summary>
        [DataMember(Name = "responses")]
        Responses MyResponses { get; set; }

        /// <summary>
        /// Gets the list 2 proxy.
        /// </summary>
        private IList<IParameter> List2Proxy
        {
            get
            {
                if (list2Proxy == null)
                    Interlocked.CompareExchange(
                        ref list2Proxy,
                        new ConvertingList<Parameter, IParameter>(
                            () => this.RealParametersList, c => c, ToClass),
                        null);

                return list2Proxy;
            }
        }

        /// <summary>
        /// Gets or sets the parameters object list.
        /// </summary>
        [IgnoreDataMember]
        public IList<IParameter> ParametersObjectList
        {
            get
            {
                return List2Proxy;
            }

            set
            {
                if (value == null)
                {
                    RealParametersList.Clear();
                    return;
                }

                if (List2Proxy == value)
                    return;

                RealParametersList = value.Select<IParameter, Parameter>(ToClass).ToList();
            }
        }

        /// <summary>
        /// Gets or sets the responses object.
        /// </summary>
        [IgnoreDataMember]
        public IResponses ResponsesObject
        {
            get
            {
                return MyResponses;
            }

            set
            {
                MyResponses = ToClass(value);
            }
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iClass">
        /// The i class.
        /// </param>
        /// <returns>
        /// The <see cref="Parameter"/>.
        /// </returns>
        Parameter ToClass(IParameter iClass)
        {
            return (Parameter)iClass;
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iResponses">
        /// The i responses.
        /// </param>
        /// <returns>
        /// The <see cref="Responses"/>.
        /// </returns>
        Responses ToClass(IResponses iResponses)
        {
            return (Responses)iResponses;
        }
    }
}
