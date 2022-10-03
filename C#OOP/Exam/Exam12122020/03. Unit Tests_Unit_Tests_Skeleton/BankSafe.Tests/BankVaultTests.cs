using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("me", "1");
        }

        [Test]
        public void CtorWork()
        {
            var initialValue = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            var initialList = initialValue.ToImmutableDictionary().ToList();
            var vaultList = vault.VaultCells.ToList();

            for (int i = 0; i < initialList.Count; i++)
            {
                Assert.That(vaultList[i].Key,Is.EqualTo(initialList[i].Key));
                Assert.That(vaultList[i].Value,Is.EqualTo(initialList[i].Value));
            }
        }

        [Test]
        public void WhenCellDoesNotExist_ShouldThrowExeption()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("nqma", item));
        }

        [Test]
        public void WhenCellDoesNotExist_ShouldThrowExeptionMessage()
        {
            Assert.That(() => vault.AddItem("nqma", item), Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void WhenCellIsAlredyTaken_ShouldThrowExeption()
        {
            vault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>vault.AddItem("A1", new Item("Gosho", "6")));
        }

        [Test]
        public void WhenCellIsAlredyTaken_ShouldThrowExeptionMessage()
        {
            vault.AddItem("A1", item);
            Assert.That(() => vault.AddItem("A1", new Item("Gosho", "6")), Throws.ArgumentException.With.Message.EqualTo("Cell is already taken!"));
        }

        [Test]
        public void WhenCellIsAlredyExist_ShouldThrowExeption()
        {
            vault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A2", item));
        }

        [Test]
        public void WhenCellIsAlredyExist_ShouldThrowExeptionMessage()
        {
            vault.AddItem("A1", item);
            Assert.That(() => vault.AddItem("A2", item), Throws.InvalidOperationException.With.Message.EqualTo("Item is already in cell!"));
        }

        [Test]
        public void WhenItemIsAdded_ShouldCorrectMessage()
        {
            Assert.That(vault.AddItem("A1", item),Is.EqualTo("Item:1 saved successfully!"));
        }

        [Test]
        public void WhenItemIsAdded_ShouldSetItemToCell()
        {
            vault.AddItem("A1",item);
            Assert.That(vault.VaultCells["A1"],Is.EqualTo(item));
        }

        [Test]
        public void Remove_WhenCellDoesNotExist_ShouldThrowExeption()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("nqma", item));
        }

        [Test]
        public void Remove_WhenCellDoesNotExist_ShouldThrowExeptionMessage()
        {
            Assert.That(() => vault.RemoveItem("nqma", item), Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void Remove_WhenCellIsAlredyTaken_ShouldThrowExeption()
        {
            vault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1", new Item("Gosho", "6")));
        }

        [Test]
        public void Remove_WhenCellIsAlredyTaken_ShouldThrowExeptionMessage()
        {
            vault.AddItem("A1", item);
            Assert.That(() => vault.RemoveItem("A1", new Item("Gosho", "6")), Throws.ArgumentException.With.Message.EqualTo("Item in that cell doesn't exists!"));
        }

        [Test]
        public void WhenItemRemoved_ShouldCorrectMessage()
        {
            vault.AddItem("A1", item);
            Assert.That(vault.RemoveItem("A1", item), Is.EqualTo("Remove item:1 successfully!"));
        }

        [Test]
        public void WhenItemRemoved_ShouldMakeTheCellNull()
        {
            vault.AddItem("A1", item);
            Item saveItem = vault.VaultCells["A1"];
            vault.RemoveItem("A1",item);
            Assert.That(vault.VaultCells["A1"],Is.EqualTo(null));
        }
    }
}