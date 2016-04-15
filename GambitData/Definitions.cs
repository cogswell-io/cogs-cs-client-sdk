namespace GambitData
{
    using System;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;

    /// <summary>
    /// The definitions.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Definitions")]
    [Export(typeof(IDefinitions))]
    public class Definitions : IDefinitions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Definitions"/> class.
        /// </summary>
        public Definitions()
        {
            MyClientSecretResponse = new AviataApiModel();
            MyErrorMessage = new AviataApiModel();
            MyMessageResultBody = new AviataApiModel();
            MyEvent = new AviataApiModel();
            MyUuidResponse = new AviataApiModel();
            MyDataGenerationRequest = new AviataApiModel();
        }

        /// <summary>
        /// Gets or sets the my client secret response.
        /// </summary>
        [DataMember(Name = "aviata.api.model.ClientSecretResponse")]
        AviataApiModel MyClientSecretResponse { get; set; }

        /// <summary>
        /// Gets or sets the my error message.
        /// </summary>
        [DataMember(Name = "aviata.api.model.ErrorMessage")]
        AviataApiModel MyErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the my message result body.
        /// </summary>
        [DataMember(Name = "aviata.api.model.MessageResultBody")]
        AviataApiModel MyMessageResultBody { get; set; }

        /// <summary>
        /// Gets or sets the my event.
        /// </summary>
        [DataMember(Name = "aviata.api.model.Event")]
        AviataApiModel MyEvent { get; set; }

        /// <summary>
        /// Gets or sets the my uuid response.
        /// </summary>
        [DataMember(Name = "aviata.api.model.UuidResponse")]
        AviataApiModel MyUuidResponse { get; set; }

        /// <summary>
        /// Gets or sets the my data generation request.
        /// </summary>
        [DataMember(Name = "aviata.api.model.DataGenerationRequest")]
        AviataApiModel MyDataGenerationRequest { get; set; }

        /// <summary>
        /// Gets or sets the client secret response object.
        /// </summary>
        [IgnoreDataMember]
        public IAviataApiModel ClientSecretResponseObject
        {
            get
            {
                return MyClientSecretResponse;
            }

            set
            {
                MyClientSecretResponse = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the error message object.
        /// </summary>
        [IgnoreDataMember]
        public IAviataApiModel ErrorMessageObject
        {
            get
            {
                return MyErrorMessage;
            }

            set
            {
                MyErrorMessage = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the message result body object.
        /// </summary>
        [IgnoreDataMember]
        public IAviataApiModel MessageResultBodyObject
        {
            get
            {
                return MyMessageResultBody;
            }

            set
            {
                MyMessageResultBody = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the event object.
        /// </summary>
        [IgnoreDataMember]
        public IAviataApiModel EventObject
        {
            get
            {
                return MyEvent;
            }

            set
            {
                MyEvent = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the uuid response object.
        /// </summary>
        [IgnoreDataMember]
        public IAviataApiModel UuidResponseObject
        {
            get
            {
                return MyUuidResponse;
            }

            set
            {
                MyUuidResponse = ToClass(value);
            }
        }

        /// <summary>
        /// Gets or sets the data generation request object.
        /// </summary>
        [IgnoreDataMember]
        public IAviataApiModel DataGenerationRequestObject
        {
            get
            {
                return MyDataGenerationRequest;
            }

            set
            {
                MyDataGenerationRequest = ToClass(value);
            }
        }

        /// <summary>
        /// The to class.
        /// </summary>
        /// <param name="iAviataApiModel">
        /// The i aviata api model.
        /// </param>
        /// <returns>
        /// The <see cref="AviataApiModel"/>.
        /// </returns>
        AviataApiModel ToClass(IAviataApiModel iAviataApiModel)
        {
            return (AviataApiModel)iAviataApiModel;
        }
    }
}
