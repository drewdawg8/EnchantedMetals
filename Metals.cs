using BepInEx;
using System;

using Jotunn.Managers;
using Jotunn.Entities;
using Jotunn.Configs;

namespace EnchantedMetals
{
    [BepInPlugin("emetals.drew", "Enchanted Metals", "1.0.0")]
    [BepInProcess("valheim.exe")]
    internal class Metals : BaseUnityPlugin
    {



        private void Awake()
        {
            ItemManager.OnVanillaItemsAvailable += AddClonedItems;
            AddRecipes();
            AddConvserions();
            AddLocalizations();
        }

        private void AddClonedItems()
        {
            try
            {
                CustomItem tin = new CustomItem("TinEnchanted", "TinOre");
                var itemDrop = tin.ItemDrop;
                itemDrop.m_itemData.m_shared.m_name = "$item_enchantedtin";
                itemDrop.m_itemData.m_shared.m_description = "$item_enchantedtin_desc";
                itemDrop.m_itemData.m_shared.m_teleportable = true;
                ItemManager.Instance.AddItem(tin);

                CustomItem copper = new CustomItem("CopperEnchanted", "CopperOre");
                var itemDrop2 = copper.ItemDrop;
                itemDrop2.m_itemData.m_shared.m_name = "$item_enchantedcopper";
                itemDrop2.m_itemData.m_shared.m_description = "$item_enchantedcopper_desc";
                itemDrop2.m_itemData.m_shared.m_teleportable = true;
                ItemManager.Instance.AddItem(copper);

                CustomItem iron = new CustomItem("IronEnchanted", "IronScrap");
                var itemDrop3 = iron.ItemDrop;
                itemDrop3.m_itemData.m_shared.m_name = "$item_enchantediron";
                itemDrop3.m_itemData.m_shared.m_description = "$item_enchantediron_desc";
                itemDrop3.m_itemData.m_shared.m_teleportable = true;
                ItemManager.Instance.AddItem(iron);





            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding cloned item: {ex.Message}");
            }
            finally
            {
                ItemManager.OnVanillaItemsAvailable -= AddClonedItems;
            }
        }
        private void AddRecipes()
        {
            CustomRecipe e_tin = new CustomRecipe(new RecipeConfig()
            {
                Item = "TinEnchanted",
                CraftingStation = "forge",
                Requirements = new RequirementConfig[]
                {
                    new RequirementConfig {Item = "TinOre", Amount = 2 },
                    new RequirementConfig {Item = "Guck", Amount = 1}
                 }
            });
            ItemManager.Instance.AddRecipe(e_tin);

            CustomRecipe e_copper = new CustomRecipe(new RecipeConfig()
            {
                Item = "CopperEnchanted",
                CraftingStation = "forge",
                Requirements = new RequirementConfig[]
               {
                    new RequirementConfig {Item = "CopperOre", Amount = 1 },
                    new RequirementConfig {Item = "BoneFragments", Amount = 3}
                }
            });
            ItemManager.Instance.AddRecipe(e_copper);

            CustomRecipe e_iron = new CustomRecipe(new RecipeConfig()
            {
                Item = "IronEnchanted",
                CraftingStation = "forge",
                Requirements = new RequirementConfig[]
               {
                    new RequirementConfig {Item = "IronScrap", Amount = 2 },
                    new RequirementConfig {Item = "Crystal", Amount = 1}
                }
            });
            ItemManager.Instance.AddRecipe(e_iron);

        }

        private void AddConvserions()
        {
            var tinConversion = new CustomItemConversion(new SmelterConversionConfig
            {
                FromItem = "TinEnchanted",
                ToItem = "Tin"
            });

            var copperConversion = new CustomItemConversion(new SmelterConversionConfig
            {
                FromItem = "CopperEnchanted",
                ToItem = "Copper"
            });

            var ironConversion = new CustomItemConversion(new SmelterConversionConfig
            {
                FromItem = "IronEnchanted",
                ToItem = "Iron"
            });
            ItemManager.Instance.AddItemConversion(copperConversion);
            ItemManager.Instance.AddItemConversion(tinConversion);
            ItemManager.Instance.AddItemConversion(ironConversion);
        }

        private void AddLocalizations()
        {
            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations =
                {
                    {"item_enchantedtin",  "Enchanted Tin"},
                    {"item_enchantedtin_desc", "This ore can be teleported." },
                    {"item_enchantedcopper",  "Enchanted Copper"},
                    {"item_enchantedcopper_desc", "This ore can be teleported." },
                    {"item_enchantediron",  "Enchanted Iron"},
                    {"item_enchantediron_desc", "This ore can be teleported." }
                }
            });
        }


    }
}
