namespace TrainingApi.Module.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficuiltyId { get; set; }

        //Navigation property
        public Region Region { get; set; }
        public Walkdifficulity Walkdifficulity { get; set; }
    }
}
