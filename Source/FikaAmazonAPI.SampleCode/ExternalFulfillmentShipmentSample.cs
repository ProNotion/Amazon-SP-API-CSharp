using FikaAmazonAPI.AmazonSpApiSDK.Models.ExternalFulfillmentShipment;
using FikaAmazonAPI.Parameter.ExternalFulfillmentShipment;

namespace FikaAmazonAPI.SampleCode;

public class ExternalFulfillmentShipmentSample
{
    AmazonConnection amazonConnection;

    public ExternalFulfillmentShipmentSample(AmazonConnection amazonConnection)
    {
        this.amazonConnection = amazonConnection;
    }

    public void GetShipments()
    {
        // Pages through every result page internally and returns a flat list.
        // Set MaxNumberOfPages to stop after a given number of pages.
        var shipments = amazonConnection.ExternalFulfillmentShipment.GetShipments(new ParameterGetShipments
        {
            Status = Shipment.StatusEnum.CONFIRMED,
            LocationId = "LOCATION_ID",
            MaxResults = 10,
            LastUpdatedAfter = DateTime.UtcNow.AddDays(-7)
        });
    }

    public void GetShipmentsOnePageWithNextPageToken()
    {
        // ONLY USE THIS SAMPLE IF YOU NEED TO GET ONE PAGE EACH TIME, otherwise remove parameter
        // 'MaxNumberOfPages' and the library will fetch all shipments for you
        var parameter = new ParameterGetShipments
        {
            Status = Shipment.StatusEnum.CONFIRMED,
            LocationId = "LOCATION_ID",
            MaxResults = 10,
            MaxNumberOfPages = 1
        };

        var shipments = amazonConnection.ExternalFulfillmentShipment.GetShipments(parameter);

        // GetShipments leaves the token for the next unfetched page on the parameter object.
        while (!string.IsNullOrEmpty(parameter.PaginationToken))
        {
            var moreShipments = amazonConnection.ExternalFulfillmentShipment.GetShipmentsByNextToken(parameter);
            parameter.PaginationToken = moreShipments.Pagination?.NextToken;
        }
    }

    public void GetShipment()
    {
        var shipment = amazonConnection.ExternalFulfillmentShipment.GetShipment("SHIPMENT_ID");
    }

    public void ProcessShipment()
    {
        var body = new ShipmentAcknowledgementRequest
        {
            ReferenceId = "REFERENCE_ID",
            LineItems = new List<LineItemWithReason>()
            {
                new()
                {
                    LineItem = new LineItem { Id = "LINE_ITEM_ID", Quantity = 1 },
                    Reason = LineItemWithReason.ReasonEnum.CUSTOMERREQUESTED
                }
            }
        };
        amazonConnection.ExternalFulfillmentShipment.ProcessShipment("SHIPMENT_ID", ProcessShipmentOperation.CONFIRM, body);
    }

    public void CreatePackages()
    {
        var body = new Packages
        {
            _Packages = new List<Package>()
            {
                new()
                {
                    Id = "PACKAGE_ID",
                    Dimensions = new PackageDimensions
                    {
                        Length = new Dimension { Value = "10.0", DimensionUnit = Dimension.DimensionUnitEnum.CM },
                        Width = new Dimension { Value = "10.0", DimensionUnit = Dimension.DimensionUnitEnum.CM },
                        Height = new Dimension { Value = "10.0", DimensionUnit = Dimension.DimensionUnitEnum.CM }
                    },
                    Weight = new Weight { Value = "200.0", WeightUnit = Weight.WeightUnitEnum.G },
                    HazmatLabels = new List<string>(),
                    PackageLineItems = new PackageLineItems
                    {
                        new()
                        {
                            PackageLineItemId = "1",
                            Quantity = 1,
                            Pieces = 1,
                            CountryOfOrigin = "IN",
                            ItemValue = new Amount { Value = "10", CurrencyCode = "INR" },
                            SerialNumbers = new List<string>()
                        },
                        new()
                        {
                            PackageLineItemId = "2",
                            Quantity = 1,
                            SerialNumbers = new List<string>()
                        }
                    },
                    Status = Package.StatusEnum.CREATED
                }
            }
        };
        amazonConnection.ExternalFulfillmentShipment.CreatePackages("SHIPMENT_ID", body);
    }

    public void UpdatePackage()
    {
        var body = new Package
        {
            Id = "PACKAGE_ID",
            Weight = new Weight { Value = "1.5", WeightUnit = Weight.WeightUnitEnum.KG }
        };
        amazonConnection.ExternalFulfillmentShipment.UpdatePackage("SHIPMENT_ID", "PACKAGE_ID", body);
    }

    public void RetrieveShippingOptions()
    {
        var options = amazonConnection.ExternalFulfillmentShipment.RetrieveShippingOptions("SHIPMENT_ID", "PACKAGE_ID");
    }

    public void GenerateShipLabels()
    {
        var body = new ShipLabelsInput
        {
            PackageIds = new List<string> { "PACKAGE_ID" }
        };
        var labels = amazonConnection.ExternalFulfillmentShipment.GenerateShipLabels("SHIPMENT_ID", GenerateShipLabelsOperation.GENERATE, body, "SHIPPING_OPTION_ID");
    }

    public void GenerateInvoice()
    {
        amazonConnection.ExternalFulfillmentShipment.GenerateInvoice("SHIPMENT_ID");
    }

    public void RetrieveInvoice()
    {
        var invoice = amazonConnection.ExternalFulfillmentShipment.RetrieveInvoice("SHIPMENT_ID");
    }

    public void UpdatePackageStatusShipped()
    {
        var body = new PackageDeliveryStatus { Status = PackageStatus.SHIPPED };
        amazonConnection.ExternalFulfillmentShipment.UpdatePackageStatusShipped("SHIPMENT_ID", "PACKAGE_ID", body);
    }
}
