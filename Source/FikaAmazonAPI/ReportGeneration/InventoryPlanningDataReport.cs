using System;
using System.Collections.Generic;
using System.Text;
using FikaAmazonAPI.ReportGeneration.ReportDataTable;
using System.IO;

namespace FikaAmazonAPI.ReportGeneration
{
    public class InventoryPlanningDataReport
    {
        public List<InventoryPlanningDataRow> Data { get; set; } = new List<InventoryPlanningDataRow>();
        public InventoryPlanningDataReport(string path, string refNumber)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var table = Table.ConvertFromCSV(path);

            List<InventoryPlanningDataRow> values = new List<InventoryPlanningDataRow>();
            foreach (var row in table.Rows)
            {
                values.Add(InventoryPlanningDataRow.FromRow(row, refNumber));
            }
            Data = values;
        }

        public InventoryPlanningDataReport(Stream stream, string refNumber)
        {
            Data = ReportParser.ParseTableRows(stream, InventoryPlanningDataRow.FromRow, refNumber);
        }
    }

    public class InventoryPlanningDataRow
    {
        public DateTime? SnapshotDate { get; set; }
        public string SKU { get; set; }
        public string FNSKU { get; set; }
        public string ASIN { get; set; }
        public string ProductName { get; set; }
        public string Condition { get; set; }
        public int? Available { get; set; }
        public int? FcTransfer { get; set; }
        public int? PendingRemovalQuantity { get; set; }
        public int? InvAge181To330Days { get; set; }
        public int? InvAge331To365Days { get; set; }
        public int? InvAge61To90Days { get; set; }
        public int? InvAge31To60Days { get; set; }
        public int? InvAge0To30Days { get; set; }
        public int? InvAge0To90Days { get; set; }
        public int? InvAge91To180Days { get; set; }
        public int? InvAge181To270Days { get; set; }
        public int? InvAge271To365Days { get; set; }
        public int? InvAge366To455Days { get; set; }
        public int? InvAge456PlusDays { get; set; }
        public string Currency { get; set; }
        public int? QtyToBeChargedAis241To270Days { get; set; }
        public decimal? EstimatedAis241To270Days { get; set; }
        public int? QtyToBeChargedAis271To300Days { get; set; }
        public decimal? EstimatedAis271To300Days { get; set; }
        public int? QtyToBeChargedAis301To330Days { get; set; }
        public decimal? EstimatedAis301To330Days { get; set; }
        public int? QtyToBeChargedAis331To365Days { get; set; }
        public decimal? EstimatedAis331To365Days { get; set; }
        public int? QtyToBeChargedAis366To455Days { get; set; }
        public decimal? EstimatedAis366To455Days { get; set; }
        public int? QtyToBeChargedAis456PlusDays { get; set; }
        public decimal? EstimatedAis456PlusDays { get; set; }
        public int? UnitsShippedT7 { get; set; }
        public int? UnitsShippedT30 { get; set; }
        public int? UnitsShippedT60 { get; set; }
        public int? UnitsShippedT90 { get; set; }
        public string Alert { get; set; }
        public decimal? YourPrice { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? LowestPriceNewPlusShipping { get; set; }
        public decimal? LowestPriceUsed { get; set; }
        public string RecommendedAction { get; set; }
        public decimal? FeaturedofferPrice { get; set; }
        public int? WeeksOfCoverT90 { get; set; }
        public int? WeeksOfCoverT30 { get; set; }
        public int? EstimatedExcessQuantity { get; set; }
        public int? DaysOfSupply { get; set; }
        public int? SalesRank { get; set; }
        public string ProductGroup { get; set; }
        public double? StorageVolume { get; set; }
        public string StorageType { get; set; }
        public string Marketplace { get; set; }
        public string VolumeUnitMeasurement { get; set; }
        public double? ItemVolume { get; set; }
        public decimal? SellThrough { get; set; }
        public decimal? EstimatedCostSavingsOfRecommendedActions { get; set; }
        public decimal? SalesShippedLast7Days { get; set; }
        public decimal? SalesShippedLast30Days { get; set; }
        public decimal? SalesShippedLast60Days { get; set; }
        public decimal? SalesShippedLast90Days { get; set; }
        public decimal? EstimatedStorageCostNextMonth { get; set; }
        public int? InboundQuantity { get; set; }
        public int? InboundWorking { get; set; }
        public int? InboundShipped { get; set; }
        public int? InboundReceived { get; set; }
        public int? ReservedQuantity { get; set; }
        public int? ReservedFcProcessing { get; set; }
        public int? ReservedCustomerOrder { get; set; }
        public int? ReservedStaging { get; set; }
        public int? InventorySupplyAtFba { get; set; }
        public int? UnfulfillableQuantity { get; set; }
        public int? RecommendedRemovalQuantity { get; set; }
        public int? RecommendedSaleDuartionDays { get; set; }
        public decimal? RecommendedSalesPrice { get; set; }
        public int? RecommendedShipInQuantity { get; set; }
        public DateTime? RecommendedShipInDate { get; set; }
        public decimal? HistoricalDaysOfSupply { get; set; }
        public decimal? ShortTermHistoricalDaysOfSupply { get; set; }
        public decimal? LongTermHistoricalDaysOfSupply { get; set; }
        public DateTime? HistoricalDaysOfSupplyLastUpdatedDate { get; set; }
        public DateTime? InventoryAgeSnapshotDate { get; set; }
        public int? TotalDaysOfSupplyIncludingOpenShipments { get; set; }
        public string IsSeasonalInNext3Months { get; set; }
        public string SeasonName { get; set; }
        public DateTime? SeasonStartDate { get; set; }
        public DateTime? SeasonEndDate { get; set; }
        public int? HealthyInventoryLevel { get; set; }
        public string refNumber { get; set; }

        public static InventoryPlanningDataRow FromRow(TableRow rowData, string refNumber)
        {
            var row = new InventoryPlanningDataRow();
            row.SnapshotDate = DataConverter.GetDate(rowData.GetString("snapshot-date"), DataConverter.DateTimeFormat.DATE_AGING_FORMAT);
            row.SKU = rowData.GetString("sku");
            row.FNSKU = rowData.GetString("fnsku");
            row.ASIN = rowData.GetString("asin");
            row.ProductName = rowData.GetString("product-name");
            row.Condition = rowData.GetString("condition");
            row.Available = DataConverter.GetInt(rowData.GetString("available"));
            row.FcTransfer = DataConverter.GetInt(rowData.GetString("fc-transfer"));
            row.PendingRemovalQuantity = DataConverter.GetInt(rowData.GetString("pending-removal-quantity"));
            row.InvAge0To90Days = DataConverter.GetInt(rowData.GetString("inv-age-0-to-90-days"));
            row.InvAge91To180Days = DataConverter.GetInt(rowData.GetString("inv-age-91-to-180-days"));
            row.InvAge181To270Days = DataConverter.GetInt(rowData.GetString("inv-age-181-to-270-days"));
            row.InvAge271To365Days = DataConverter.GetInt(rowData.GetString("inv-age-271-to-365-days"));
            row.InvAge366To455Days = DataConverter.GetInt(rowData.GetString("inv-age-366-to-455-days"));
            row.InvAge456PlusDays = DataConverter.GetInt(rowData.GetString("inv-age-456-plus-days"));
            row.Currency = rowData.GetString("currency");
            row.QtyToBeChargedAis241To270Days = DataConverter.GetInt(rowData.GetString("quantity-to-be-charged-ais-241-270-days"));
            row.EstimatedAis241To270Days = DataConverter.GetDecimal(rowData.GetString("estimated-ais-241-270-days"));
            row.QtyToBeChargedAis271To300Days = DataConverter.GetInt(rowData.GetString("quantity-to-be-charged-ais-271-300-days"));
            row.EstimatedAis271To300Days = DataConverter.GetDecimal(rowData.GetString("estimated-ais-271-300-days"));
            row.QtyToBeChargedAis301To330Days = DataConverter.GetInt(rowData.GetString("quantity-to-be-charged-ais-301-330-days"));
            row.EstimatedAis301To330Days = DataConverter.GetDecimal(rowData.GetString("estimated-ais-301-330-days"));
            row.QtyToBeChargedAis331To365Days = DataConverter.GetInt(rowData.GetString("quantity-to-be-charged-ais-331-365-days"));
            row.EstimatedAis331To365Days = DataConverter.GetDecimal(rowData.GetString("estimated-ais-331-365-days"));
            row.QtyToBeChargedAis366To455Days = DataConverter.GetInt(rowData.GetString("quantity-to-be-charged-ais-366-455-days"));
            row.EstimatedAis366To455Days = DataConverter.GetDecimal(rowData.GetString("estimated-ais-366-455-days"));
            row.QtyToBeChargedAis456PlusDays = DataConverter.GetInt(rowData.GetString("quantity-to-be-charged-ais-456-plus-days"));
            row.EstimatedAis456PlusDays = DataConverter.GetDecimal(rowData.GetString("estimated-ais-456-plus-days"));
            row.UnitsShippedT7 = DataConverter.GetInt(rowData.GetString("units-shipped-t7"));
            row.UnitsShippedT30 = DataConverter.GetInt(rowData.GetString("units-shipped-t30"));
            row.UnitsShippedT60 = DataConverter.GetInt(rowData.GetString("units-shipped-t60"));
            row.UnitsShippedT90 = DataConverter.GetInt(rowData.GetString("units-shipped-t90"));
            row.Alert = rowData.GetString("alert");
            row.YourPrice = DataConverter.GetDecimal(rowData.GetString("your-price"));
            row.SalesPrice = DataConverter.GetDecimal(rowData.GetString("sales-price"));
            row.LowestPriceNewPlusShipping = DataConverter.GetDecimal(rowData.GetString("lowest-price-new-plus-shipping"));
            row.LowestPriceUsed = DataConverter.GetDecimal(rowData.GetString("lowest-price-used"));
            row.RecommendedAction = rowData.GetString("recommended-action");
            row.HealthyInventoryLevel = DataConverter.GetInt(rowData.GetString("healthy-inventory-level"));
            row.RecommendedSalesPrice = DataConverter.GetDecimal(rowData.GetString("recommended-sales-price"));
            row.RecommendedSaleDuartionDays = DataConverter.GetInt(rowData.GetString("recommended-sale-duration-days"));
            row.RecommendedRemovalQuantity = DataConverter.GetInt(rowData.GetString("recommended-removal-quantity"));
            row.EstimatedCostSavingsOfRecommendedActions = DataConverter.GetDecimal(rowData.GetString("estimated-cost-savings-of-recommended-actions"));
            row.SellThrough = DataConverter.GetDecimal(rowData.GetString("sell-through"));
            row.ItemVolume = DataConverter.GetDouble(rowData.GetString("item-volume"));
            row.VolumeUnitMeasurement = rowData.GetString("volume-unit-measurement");
            row.StorageType = rowData.GetString("storage-type");
            row.StorageVolume = DataConverter.GetDouble(rowData.GetString("storage-volume"));
            row.Marketplace = rowData.GetString("marketplace");
            row.ProductGroup = rowData.GetString("product-group");
            row.SalesRank = DataConverter.GetInt(rowData.GetString("sales-rank"));
            row.DaysOfSupply = DataConverter.GetInt(rowData.GetString("days-of-supply"));
            row.EstimatedExcessQuantity = DataConverter.GetInt(rowData.GetString("estimated-excess-quantity"));
            row.WeeksOfCoverT30 = DataConverter.GetInt(rowData.GetString("weeks-of-cover-t30"));
            row.WeeksOfCoverT90 = DataConverter.GetInt(rowData.GetString("weeks-of-cover-t90"));
            row.FeaturedofferPrice = DataConverter.GetDecimal(rowData.GetString("featuredoffer-price"));
            row.SalesShippedLast7Days = DataConverter.GetDecimal(rowData.GetString("sales-shipped-last-7-days"));
            row.SalesShippedLast30Days = DataConverter.GetDecimal(rowData.GetString("sales-shipped-last-30-days"));
            row.SalesShippedLast60Days = DataConverter.GetDecimal(rowData.GetString("sales-shipped-last-60-days"));
            row.SalesShippedLast90Days = DataConverter.GetDecimal(rowData.GetString("sales-shipped-last-90-days"));
            row.InvAge0To30Days = DataConverter.GetInt(rowData.GetString("inv-age-0-to-30-days"));
            row.InvAge31To60Days = DataConverter.GetInt(rowData.GetString("inv-age-31-to-60-days"));
            row.InvAge61To90Days = DataConverter.GetInt(rowData.GetString("inv-age-61-to-90-days"));
            row.InvAge181To330Days = DataConverter.GetInt(rowData.GetString("inv-age-181-to-330-days"));
            row.InvAge331To365Days = DataConverter.GetInt(rowData.GetString("inv-age-331-to-365-days"));
            row.EstimatedStorageCostNextMonth = DataConverter.GetDecimal(rowData.GetString("estimated-storage-cost-next-month"));
            row.InboundQuantity = DataConverter.GetInt(rowData.GetString("inbound-quantity"));
            row.InboundWorking = DataConverter.GetInt(rowData.GetString("inbound-working"));
            row.InboundShipped = DataConverter.GetInt(rowData.GetString("inbound-shipped"));
            row.InboundReceived = DataConverter.GetInt(rowData.GetString("inbound-received"));
            row.ReservedQuantity = DataConverter.GetInt(rowData.GetString("Total Reserved Quantity"));
            row.ReservedFcProcessing = DataConverter.GetInt(rowData.GetString("Reserved FC Processing"));
            row.ReservedCustomerOrder = DataConverter.GetInt(rowData.GetString("Reserved Customer Order"));
            row.ReservedStaging = DataConverter.GetInt(rowData.GetString("Reserved Staging"));
            row.InventorySupplyAtFba = DataConverter.GetInt(rowData.GetString("Inventory Supply at FBA"));
            row.UnfulfillableQuantity = DataConverter.GetInt(rowData.GetString("unfulfillable-quantity"));
            row.RecommendedShipInQuantity = DataConverter.GetInt(rowData.GetString("Recommended ship-in quantity"));
            row.RecommendedShipInDate = DataConverter.GetDate(rowData.GetString("Recommended ship-in date"), DataConverter.DateTimeFormat.DATE_AGING_FORMAT);
            row.HistoricalDaysOfSupply = DataConverter.GetDecimal(rowData.GetString("historical-days-of-supply"));
            row.ShortTermHistoricalDaysOfSupply = DataConverter.GetDecimal(rowData.GetString("Short term historical days of supply"));
            row.LongTermHistoricalDaysOfSupply = DataConverter.GetDecimal(rowData.GetString("Long term historical days of supply"));
            row.HistoricalDaysOfSupplyLastUpdatedDate = DataConverter.GetDate(rowData.GetString("Last updated date for Historical Days of Supply"), DataConverter.DateTimeFormat.DATE_AGING_FORMAT);
            row.InventoryAgeSnapshotDate = DataConverter.GetDate(rowData.GetString("Inventory age snapshot date"), DataConverter.DateTimeFormat.DATE_AGING_FORMAT);
            row.TotalDaysOfSupplyIncludingOpenShipments = DataConverter.GetInt(rowData.GetString("Total Days of Supply (including units from open shipments)"));
            row.IsSeasonalInNext3Months = rowData.GetString("is-seasonal-in-next-3-months");
            row.SeasonName = rowData.GetString("season-name");
            row.SeasonStartDate = DataConverter.GetDate(rowData.GetString("season-start-date"), DataConverter.DateTimeFormat.DATE_AGING_FORMAT);
            row.SeasonEndDate = DataConverter.GetDate(rowData.GetString("season-end-date"), DataConverter.DateTimeFormat.DATE_AGING_FORMAT);
            row.refNumber = refNumber;
            return row;
        }

    }
}
