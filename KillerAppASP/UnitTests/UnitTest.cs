using KillerAppASP.Helperclasses;
using KillerAppASP.TestContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestNoiseGenerator()
        {
            bool result;
            int Size, Seed;
            float[,] FirstMap, SecondMap;

            //Precies dezelfde mappen, zou true moeten zijn.
            Size = 200; Seed = 1;
            FirstMap = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            Size = 200; Seed = 1;
            SecondMap = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            result = CompareSameSizeArrays(FirstMap, SecondMap);           
        
            Assert.IsTrue(result);

            //Verschillende seed, zou false moeten zijn.
            Size = 200; Seed = 1;
            FirstMap = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            Size = 200; Seed = 5;
            SecondMap = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            result = CompareSameSizeArrays(FirstMap, SecondMap);

            Assert.IsFalse(result);

            //Verschillende grootte maar zelfde seed.
            //Hierbij zou de kleinere map precies hetzelfde moeten zijn als het deel van de grote map in de linkerbovenhoek.
            //Tenminste, op een afbeelding lijkt het hetzelfde te zijn, maar na de mappen te vergelijken, blijken de waardes toch af te wijken.
            //Moeilijk om dit exact te testen. Maps met andere seed kunnen misschien toch zoveel op elkaar lijken dat test false positive of false negative geeft.
            //(Kans is wel klein).
            Size = 200; Seed = 6;
            FirstMap = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            Size = 800; Seed = 6;
            SecondMap = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            result = CompareDifferentSizeArrays(FirstMap, SecondMap);

            Assert.IsTrue(result);

            //Verschillende grootte en andere seed
            Size = 200; Seed = 6;
            FirstMap = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            Size = 800; Seed = 9;
            SecondMap = PerlinNoiseGenerator.GenerateMap(Size, Seed);
            result = CompareDifferentSizeArrays(FirstMap, SecondMap);

            Assert.IsFalse(result);
        }

        private bool CompareSameSizeArrays(float[,] First, float[,] Second)
        {
            bool Same = true;
            for (int y = 0; y < First.GetLength(0); y++)
            {
                for (int x = 0; x < First.GetLength(1); x++)
                {
                    if(First[x,y] != Second[x,y])
                    {
                        Same = false;
                    }
                }
            }
            return Same;
        }

        private bool CompareDifferentSizeArrays(float[,] Small, float[,] Big)
        {
            bool Same = true;
            for (int y = 0; y < Small.GetLength(0); y++)
            {
                for (int x = 0; x < Small.GetLength(1); x++)
                {
                    if (Small[x, y] > (Big[x, y] + 0.1f) || Small[x, y] < (Big[x, y] - 0.1f))
                    {
                        Same = false;
                    }
                }
            }
            return Same;
        }



        [TestMethod]
        public void TestColorSelector() //Test of verschillende waardes en grondtypes de goede kleur teruggeven, hierbij worden ook grens of overschrijdendne waarden getest.
        {
            int Value, GroundType;
            Color color;

            Value = -5; GroundType = 0;
            color = TileColorSelector.SelectTileColor(Value, GroundType);
            Assert.AreEqual(Color.DodgerBlue, color);

            Value = 120; GroundType = 0;
            color = TileColorSelector.SelectTileColor(Value, GroundType);
            Assert.AreEqual(Color.Green, color);

            Value = 500; GroundType = 0;
            color = TileColorSelector.SelectTileColor(Value, GroundType);
            Assert.AreEqual(Color.White, color);

            Value = 40; GroundType = 1;
            color = TileColorSelector.SelectTileColor(Value, GroundType);
            Assert.AreEqual(Color.LightSlateGray, color);

            Value = 144; GroundType = 1;
            color = TileColorSelector.SelectTileColor(Value, GroundType);
            Assert.AreEqual(Color.Snow, color);

            Value = 220; GroundType = 2;
            color = TileColorSelector.SelectTileColor(Value, GroundType);
            Assert.AreEqual(Color.SaddleBrown, color);

            Value = 120; GroundType = -1;
            color = TileColorSelector.SelectTileColor(Value, GroundType);
            Assert.AreEqual(Color.Green, color);

            Value = 120; GroundType = 200;
            color = TileColorSelector.SelectTileColor(Value, GroundType);
            Assert.AreEqual(Color.Green, color);
        }

        [TestMethod]
        public void TestSearch() //Test voor verschillende zoektermen of de juiste users gevonden worden.
        {
            string SearchTerm;
            TestUserRepository testUserRepository = new TestUserRepository(new TestUserContext());

            SearchTerm = "nick";
            testUserRepository.SearchUsers(SearchTerm);
            Assert.AreEqual(2, testUserRepository.FoundUsers.Count);

            SearchTerm = "";           
            testUserRepository.SearchUsers(SearchTerm);
            Assert.AreEqual(testUserRepository.Users.Count, testUserRepository.FoundUsers.Count);

            SearchTerm = "thijssen";          
            testUserRepository.SearchUsers(SearchTerm);
            Assert.AreEqual(4, testUserRepository.FoundUsers.Count);

            SearchTerm = "ckth";
            testUserRepository.SearchUsers(SearchTerm);
            Assert.AreEqual(2, testUserRepository.FoundUsers.Count);

            SearchTerm = "se";
            testUserRepository.SearchUsers(SearchTerm);
            Assert.AreEqual(4, testUserRepository.FoundUsers.Count);

            SearchTerm = "1994";
            testUserRepository.SearchUsers(SearchTerm);
            Assert.AreEqual(2, testUserRepository.FoundUsers.Count);

            SearchTerm = " ";
            testUserRepository.SearchUsers(SearchTerm);
            Assert.AreEqual(0, testUserRepository.FoundUsers.Count);

            SearchTerm = "piet";
            testUserRepository.SearchUsers(SearchTerm);
            Assert.AreEqual(0, testUserRepository.FoundUsers.Count);

            SearchTerm = "nickthijssen1994";
            testUserRepository.SearchUsers(SearchTerm);
            Assert.AreEqual(1, testUserRepository.FoundUsers.Count);
        }
    }
}