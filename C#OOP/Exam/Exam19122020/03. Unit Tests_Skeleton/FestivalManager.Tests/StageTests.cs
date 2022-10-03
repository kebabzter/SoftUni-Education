// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
	{
		private Stage stage=null;
		[SetUp]
		public void SetUp()
		{
			stage = new Stage();
		}
		[Test]
	    public void addPerformer_performerCanNotBeNull()
	    {
			Assert.Throws<ArgumentNullException>(()=> stage.AddPerformer(null));
		}

		[Test]
		public void addPerformer_performerUnder18Age()
		{
			var performer = new Performer("Ivan","Ivanov",5);
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
		}

		[Test]
		public void addPerformer_performerSucces()
		{
			var performer = new Performer("Ivan", "Ivanov", 25);
			stage.AddPerformer(performer);
			Assert.That(stage.Performers.Count,Is.EqualTo(1));
			Assert.That(stage.Performers.FirstOrDefault(),Is.EqualTo(performer));
		}

		

		[Test]
		public void addSong_CanNotBeNull()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}

		[Test]
		public void addSong_durationUnder1()
		{
			var song = new Song("ImeSong",new TimeSpan(0,0,30));
			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}

		[Test]
		public void songName_SongMustNotBeNull()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null,"Gosho"));
		}

		[Test]
		public void performerName_SongMustNotBeNull()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("GogiSong", null));
		}

		[Test]
		public void addSongToPerformer_Succes()
		{
			var performer = new Performer("Ivan", "Ivanov", 25);
			var song = new Song("SongName",new TimeSpan(0,1,30));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("SongName","Ivan Ivanov");

			Assert.That(performer.SongList.Count, Is.EqualTo(1));
			Assert.That(performer.SongList.FirstOrDefault(), Is.EqualTo(song));
		}

		[Test]
		public void addSongToPerformer_SuccesReturnString()
		{
			var performer = new Performer("Ivan", "Ivanov", 25);
			var song = new Song("SongName", new TimeSpan(0, 1, 30));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			
			Assert.That(stage.AddSongToPerformer("SongName", "Ivan Ivanov"), Is.EqualTo("SongName (01:30) will be performed by Ivan Ivanov"));
		}

		[Test]
		public void addSongToPerformer_ThrowExeptionSong()
		{
			var performer = new Performer("Ivan", "Ivanov", 25);
			stage.AddPerformer(performer);
			
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("nqma", "Ivan Ivanov"));
		}

		[Test]
		public void addSongToPerformer_ThrowExeptionPerformer()
		{
			var song = new Song("SongName",new TimeSpan(0,1,30));
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("SongName", "Ivan Ivanov"));
		}
		[Test]
		public void stagePlay()
		{
			var performer = new Performer("Ivan", "Ivanov", 25);
			var song = new Song("SongName", new TimeSpan(0, 1, 30));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("SongName", "Ivan Ivanov");
			string result = stage.Play();

			Assert.That(result,Is.EqualTo("1 performers played 1 songs"));	
		}


	}
}