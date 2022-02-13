namespace Make_Way_Jump
{
    public class BlockInitializer
    {
        private readonly Spawner _spawner;
        
        public BlockInitializer(BlocksData blocksData)
        {
            _spawner = new Spawner(blocksData.Blocks);
        }

        public void Initialize()
        {
            
        }
    }
}  