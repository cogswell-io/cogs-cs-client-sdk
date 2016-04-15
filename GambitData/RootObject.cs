namespace GambitData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The root object.
    /// </summary>
    [Serializable]
    [DataContract(Name = "RootObject")]
    [Export(typeof(IRootObject))]
    public class RootObject : IRootObject
    {
        public RootObject()
        {
            MyPaths = new Paths();
            MyInfo = new Info();
            MyDefinitions = new Definitions();
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iDefinitions">
        /// The i definitions.
        /// </param>
        /// <returns>
        /// The <see cref="Definitions"/>.
        /// </returns>
        Definitions ToClass(IDefinitions iDefinitions)
        {
            return (Definitions)iDefinitions;
        }

        /// <summary>
        /// Gets or sets the my paths.
        /// </summary>
        [DataMember(Name = "paths")]
        Paths MyPaths { get; set; }

        /// <summary>
        /// Gets or sets the my info.
        /// </summary>
        [DataMember(Name = "info")]
        Info MyInfo { get; set; }

        /// <summary>
        /// Gets or sets the produces.
        /// </summary>
        [DataMember(Name = "produces")]
        public IEnumerable<string> Produces { get; set; }

        /// <summary>
        /// Gets or sets the my definitions.
        /// </summary>
        [DataMember(Name = "definitions")]
        Definitions MyDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the gambit.
        /// </summary>
        [DataMember(Name = "swagger")]
        public string Gambit { get; set; }

        /// <summary>
        /// Gets or sets the paths object.
        /// </summary>
        [IgnoreDataMember]
        public IPaths PathsObject
        {
            get
            {
                return MyPaths;
            }

            set
            {
                MyPaths = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the info object.
        /// </summary>
        [IgnoreDataMember]
        public IInfo InfoObject
        {
            get
            {
                return MyInfo;
            }

            set
            {
                MyInfo = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the definitions object.
        /// </summary>
        [IgnoreDataMember]
        public IDefinitions DefinitionsObject
        {
            get
            {
                return MyDefinitions;
            }

            set
            {
                MyDefinitions = ToClass(value);
            }
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iPaths">
        /// The i paths.
        /// </param>
        /// <returns>
        /// The <see cref="Paths"/>.
        /// </returns>
        Paths ToClass(IPaths iPaths)
        {
            return (Paths)iPaths;
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iInfo">
        /// The i info.
        /// </param>
        /// <returns>
        /// The <see cref="Info"/>.
        /// </returns>
        Info ToClass(IInfo iInfo)
        {
            return (Info)iInfo;
        }
    }
}
