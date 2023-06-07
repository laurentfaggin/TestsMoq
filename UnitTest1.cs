using Moq;
using M02_UT_ConsolidationAbonnes;


namespace Tests_M02_UT_ConsolidationAbonnes
{
    public class UnitTest1
    {
        [Fact]
        public void ConsoliderDonneesDestination_SourceAUnAbonne_DestinationVide()
        {
            Mock<IDepotAbonnes> mockDestination = new Mock<IDepotAbonnes>();
            Mock<IDepotImportationAbonnes> mockSource = new Mock<IDepotImportationAbonnes>();
            Abonne abonneSource = new Abonne();

            mockSource.Setup(s => s.ObtenirAbonnes()).Returns(new List<Abonne>() { abonneSource });
            mockDestination.Setup(d => d.ObtenirAbonnes()).Returns(new List<Abonne>());

            TraitementLotsConsolidationAbonnes traitement = new TraitementLotsConsolidationAbonnes(mockSource.Object, mockDestination.Object);

            traitement.ConsoliderDonneesDestination();

            mockSource.Verify(s => s.ObtenirAbonnes(), Times.AtLeastOnce());
            mockDestination.Verify(d => d.ObtenirAbonnes(), Times.AtLeastOnce());
            mockDestination.Verify(d => d.AjouterAbonne(abonneSource), Times.Once());
            mockSource.VerifyNoOtherCalls();
            mockDestination.VerifyNoOtherCalls();

        }

        [Fact]
        public void ConsoliderDonneesDestination_SourceVide_DestinationNonVide()
        {
            Mock<IDepotAbonnes> mockDestination = new Mock<IDepotAbonnes>();
            Mock<IDepotImportationAbonnes> mockSource = new Mock<IDepotImportationAbonnes>();
            Abonne abonneDestination = new Abonne();
            List <Abonne> abonnesDestination = new List<Abonne>() { abonneDestination };

            mockSource.Setup(s => s.ObtenirAbonnes()).Returns(new List<Abonne>());
            mockDestination.Setup(d => d.ObtenirAbonnes()).Returns(abonnesDestination);

            TraitementLotsConsolidationAbonnes traitement = new TraitementLotsConsolidationAbonnes (mockSource.Object, mockDestination.Object);

            traitement.ConsoliderDonneesDestination();

            mockSource.Verify(s => s.ObtenirAbonnes(), Times.AtLeastOnce());
            mockDestination.Verify(d => d.ObtenirAbonnes(), Times.AtLeastOnce());
            mockDestination.Verify(d => d.DesactiverAbonne(abonneDestination.AbonneId), Times.Once());
            mockSource.VerifyNoOtherCalls();
            mockDestination.VerifyNoOtherCalls();
        }

        [Fact]
        public void ConsoliderDonneesDestination_Source_Destination_AbonnesIdentiques()
        {
            Mock<IDepotAbonnes> mockDestination = new Mock<IDepotAbonnes>();
            Mock<IDepotImportationAbonnes> mockSource = new Mock<IDepotImportationAbonnes>();
            Abonne abonneSource = new Abonne();
            Abonne abonneDestination = abonneSource;
            List<Abonne> abonnesDestination = new List<Abonne>(); 
            List<Abonne> abonnesSource = new List<Abonne>();

            abonnesSource.Add(abonneSource);
            abonnesDestination.Add(abonneDestination);

            mockSource.Setup(s => s.ObtenirAbonnes()).Returns(abonnesSource);
            mockDestination.Setup(d => d.ObtenirAbonnes()).Returns(abonnesDestination);
           

            TraitementLotsConsolidationAbonnes traitement = new TraitementLotsConsolidationAbonnes(mockSource.Object, mockDestination.Object);
            traitement.ConsoliderDonneesDestination();

            Assert.Equal(abonneSource, abonneDestination);
            mockSource.Verify(s => s.ObtenirAbonnes(), Times.AtLeastOnce());
            mockDestination.Verify(d => d.ObtenirAbonnes(), Times.AtLeastOnce());
            mockSource.VerifyNoOtherCalls();
            mockDestination.VerifyNoOtherCalls();

        }

        [Fact]
        public void ConsoliderDonneesDestination_Source_Destination_PrenomDifferent()
        {
            Mock<IDepotAbonnes> mockDestination = new Mock<IDepotAbonnes>();
            Mock<IDepotImportationAbonnes> mockSource = new Mock<IDepotImportationAbonnes>();
            Abonne abonneSource = new Abonne() { AbonneId = 123, Prenom = "Laurent" };
            Abonne abonneDestination = new Abonne() { AbonneId = 123, Prenom = "Florent" };
            List<Abonne> abonnesDestination = new List<Abonne>() { abonneDestination };
            List<Abonne> abonnesSource = new List<Abonne>() { abonneSource };

            mockSource.Setup(s => s.ObtenirAbonnes()).Returns(abonnesSource);
            mockDestination.Setup(d => d.ObtenirAbonnes()).Returns(abonnesDestination);

            TraitementLotsConsolidationAbonnes traitement = new TraitementLotsConsolidationAbonnes(mockSource.Object, mockDestination.Object);
            traitement.ConsoliderDonneesDestination();

            mockSource.Verify(s => s.ObtenirAbonnes(), Times.AtLeastOnce());
            mockSource.VerifyNoOtherCalls();
            mockDestination.Verify(d => d.ObtenirAbonnes(), Times.AtLeastOnce());
            mockDestination.Verify(d => d.MettreAjourAbonne(abonneDestination), Times.Once());
            mockDestination.VerifyNoOtherCalls();
        }

        [Fact]
        public void ConsoliderDonneesDestination_Source3Abonnes_Destination2Abonnes_1AbonneEgal_1AbonneDifferent_1AbonneExistePasDansdestination()
        {
            Mock<IDepotAbonnes> mockDestination = new Mock<IDepotAbonnes>();
            Mock<IDepotImportationAbonnes> mockSource = new Mock<IDepotImportationAbonnes>();
            Abonne abonneSource1 = new Abonne() { AbonneId = 123, Prenom = "Laurent" };
            Abonne abonneSource2 = new Abonne() { AbonneId = 256 };
            Abonne abonneSource3 = new Abonne() { AbonneId = 512 };
            Abonne abonneDestination1 = new Abonne() {  AbonneId = 123, Prenom = "Florent" };
            Abonne abonneDestination2 = new Abonne() {  AbonneId = 512 };


            List<Abonne> abonnesDestination = new List<Abonne>() { abonneDestination1, abonneDestination2 };
            List<Abonne> abonnesSource = new List<Abonne>() { abonneSource1, abonneSource2, abonneSource3 };

            mockSource.Setup(s => s.ObtenirAbonnes()).Returns(abonnesSource);
            mockDestination.Setup(d => d.ObtenirAbonnes()).Returns(abonnesDestination);

            TraitementLotsConsolidationAbonnes traitement = new TraitementLotsConsolidationAbonnes(mockSource.Object, mockDestination.Object);
            traitement.ConsoliderDonneesDestination();

            mockSource.Verify(s => s.ObtenirAbonnes(), Times.AtLeastOnce());
            mockSource.VerifyNoOtherCalls();
            mockDestination.Verify(d => d.ObtenirAbonnes(), Times.AtLeastOnce());
            mockDestination.Verify(d => d.AjouterAbonne(abonneSource2), Times.Once());
            mockDestination.Verify(d => d.MettreAjourAbonne(abonneDestination1), Times.Once());;
            mockDestination.VerifyNoOtherCalls();
        }
    }
}