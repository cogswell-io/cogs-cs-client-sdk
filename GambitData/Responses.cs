namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The responses.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Responses")]
    [Export(typeof(IResponses))]
    public class Responses : IResponses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Responses"/> class.
        /// </summary>
        public Responses()
        {
            MyCode200 = new ResponseCodeBody();
            MyCode400 = new ResponseCodeBody();
            MyCode401 = new ResponseCodeBody();
            MyCode418 = new ResponseCodeBody();
            MyCode500 = new ResponseCodeBody();
        }

        /// <summary>
        /// Gets or sets the my code 200.
        /// </summary>
        [DataMember(Name = "200")]
        ResponseCodeBody MyCode200 { get; set; }

        /// <summary>
        /// Gets or sets the my code 400.
        /// </summary>
        [DataMember(Name = "400")]
        ResponseCodeBody MyCode400 { get; set; }

        /// <summary>
        /// Gets or sets the my code 401.
        /// </summary>
        [DataMember(Name = "401")]
        ResponseCodeBody MyCode401 { get; set; }

        /// <summary>
        /// Gets or sets the my code 418.
        /// </summary>
        [DataMember(Name = "418")]
        ResponseCodeBody MyCode418 { get; set; }

        /// <summary>
        /// Gets or sets the my code 500.
        /// </summary>
        [DataMember(Name = "500")]
        ResponseCodeBody MyCode500 { get; set; }

        /// <summary>
        /// Gets or sets the code 200 object.
        /// </summary>
        [IgnoreDataMember]
        public IResponseCodeBody Code200Object
        {
            get
            {
                if (MyCode200 == null)
                {
                    MyCode200 = new ResponseCodeBody()
                    {
                        Description = String.Empty
                    };
                }

                return this.MyCode200;
            }

            set
            {
                MyCode200 = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the code 400 object.
        /// </summary>
        [IgnoreDataMember]
        public IResponseCodeBody Code400Object
        {
            get
            {
                if (MyCode400 == null)
                {
                    MyCode400 = new ResponseCodeBody()
                    {
                        Description = String.Empty
                    };
                }

                return MyCode400;
            }

            set
            {
                MyCode400 = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the code 401 object.
        /// </summary>
        [IgnoreDataMember]
        public IResponseCodeBody Code401Object
        {
            get
            {
                if (MyCode401 == null)
                {
                    MyCode401 = new ResponseCodeBody()
                    {
                        Description = String.Empty
                    };
                }

                return MyCode401;
            }

            set
            {
                MyCode401 = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the code 418 object.
        /// </summary>
        [IgnoreDataMember]
        public IResponseCodeBody Code418Object
        {
            get
            {
                if (MyCode418 == null)
                {
                    MyCode418 = new ResponseCodeBody()
                    {
                        Description = String.Empty
                    };
                }

                return MyCode418;
            }

            set
            {
                MyCode418 = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the code 500 object.
        /// </summary>
        [IgnoreDataMember]
        public IResponseCodeBody Code500Object
        {
            get
            {
                if (MyCode500 == null)
                {
                    MyCode500 = new ResponseCodeBody()
                    {
                        Description = String.Empty
                    };
                }

                return MyCode500;
            }

            set
            {
                MyCode500 = ToClass(value);
            }
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iResponseCodeBody">
        /// The i response code body.
        /// </param>
        /// <returns>
        /// The <see cref="ResponseCodeBody"/>.
        /// </returns>
        ResponseCodeBody ToClass(IResponseCodeBody iResponseCodeBody)
        {
            return (ResponseCodeBody)iResponseCodeBody;
        }
    }
}
