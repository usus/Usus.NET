using System.Collections.ObjectModel;
using System.Windows.Media;

namespace andrena.Usus.net.View.ViewModels.CleanCode
{
    public class CleanCodeRanks
    {
        public ObservableCollection<CleanCodeRank> Ranks { get; private set; }

        public CleanCodeRanks()
        {
            Ranks = new ObservableCollection<CleanCodeRank>();
            InitializeRanks();
        }

        private CleanCodeRank NewRank(Color color, string name)
        {
            var rank = new CleanCodeRank(color, name);
            Ranks.Add(rank);
            return rank;
        }

        private void InitializeRanks()
        {
            var black = NewRank(Colors.Black, "1. Grad");
            black.Principles.Add(new CleanCodePrinciple { Name = "Be motivated", Link = "http://www.clean-code-developer.de/Schwarzer-Grad.ashx" });

            var red = NewRank(Colors.Red, "2. Grad");
            red.Principles.Add(new CleanCodePrinciple { Name = "Don´t Repeat Yourself (DRY)", Link = "http://www.clean-code-developer.de/Roter-Grad.ashx#Don´t_Repeat_Yourself_DRY_0" });
            red.Principles.Add(new CleanCodePrinciple { Name = "Keep it simple, stupid (KISS)", Link = "http://www.clean-code-developer.de/Roter-Grad.ashx#Keep_it_simple_stupid_KISS_1" });
            red.Principles.Add(new CleanCodePrinciple { Name = "Vorsicht vor Optimierungen!", Link = "http://www.clean-code-developer.de/Roter-Grad.ashx#Vorsicht_vor_Optimierungen!_2" });
            red.Principles.Add(new CleanCodePrinciple { Name = "Favour Composition over Inheritance (FCoI)", Link = "http://www.clean-code-developer.de/Roter-Grad.ashx#Favour_Composition_over_Inheritance_FCoI_3" });
            red.Practices.Add(new CleanCodePractice { Name = "Die Pfadfinderregel beachten", Link = "http://www.clean-code-developer.de/Roter-Grad.ashx#Die_Pfadfinderregel_beachten_4" });
            red.Practices.Add(new CleanCodePractice { Name = "Root Cause Analysis", Link = "http://www.clean-code-developer.de/Roter-Grad.ashx#Root_Cause_Analysis_5" });
            red.Practices.Add(new CleanCodePractice { Name = "Ein Versionskontrollsystem einsetzen", Link = "http://www.clean-code-developer.de/Roter-Grad.ashx#Ein_Versionskontrollsystem_einsetzen_6" });
            red.Practices.Add(new CleanCodePractice { Name = "Einfache Refaktorisierungsmuster anwenden", Link = "http://www.clean-code-developer.de/Roter-Grad.ashx#Einfache_Refaktorisierungsmuster_anwenden_7" });
            red.Practices.Add(new CleanCodePractice { Name = "Täglich reflektieren", Link = "http://www.clean-code-developer.de/Roter-Grad.ashx#Täglich_reflektieren_8" });

            var orange = NewRank(Colors.Orange, "3. Grad");
            orange.Principles.Add(new CleanCodePrinciple { Name = "Single Level of Abstraction (SLA)", Link = "http://www.clean-code-developer.de/Oranger-Grad.ashx#Single_Level_of_Abstraction_SLA_0" });
            orange.Principles.Add(new CleanCodePrinciple { Name = "Single Responsibility Principle (SRP)", Link = "http://www.clean-code-developer.de/Oranger-Grad.ashx#Single_Responsibility_Principle_SRP_1" });
            orange.Principles.Add(new CleanCodePrinciple { Name = "Separation of Concerns (SoC)", Link = "http://www.clean-code-developer.de/Oranger-Grad.ashx#Separation_of_Concerns_SoC_2" });
            orange.Principles.Add(new CleanCodePrinciple { Name = "Source Code Konventionen", Link = "http://www.clean-code-developer.de/Oranger-Grad.ashx#Source_Code_Konventionen_3" });
            orange.Practices.Add(new CleanCodePractice { Name = "Issue Tracking", Link = "http://www.clean-code-developer.de/Oranger-Grad.ashx#Issue_Tracking_4" });
            orange.Practices.Add(new CleanCodePractice { Name = "Automatisierte Integrationstests", Link = "http://www.clean-code-developer.de/Oranger-Grad.ashx#Automatisierte_Integrationstests_5" });
            orange.Practices.Add(new CleanCodePractice { Name = "Lesen, Lesen, Lesen", Link = "http://www.clean-code-developer.de/Oranger-Grad.ashx#Lesen_Lesen_Lesen_6" });
            orange.Practices.Add(new CleanCodePractice { Name = "Reviews", Link = "http://www.clean-code-developer.de/Oranger-Grad.ashx#Reviews_7" });

            var yellow = NewRank(Colors.Yellow, "4. Grad");
            yellow.Principles.Add(new CleanCodePrinciple { Name = "Interface Segregation Principle (ISP)", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Interface_Segregation_Principle_ISP_0" });
            yellow.Principles.Add(new CleanCodePrinciple { Name = "Dependency Inversion Principle", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Dependency_Inversion_Principle_1" });
            yellow.Principles.Add(new CleanCodePrinciple { Name = "Liskov Substitution Principle", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Liskov_Substitution_Principle_2" });
            yellow.Principles.Add(new CleanCodePrinciple { Name = "Principle of Least Astonishment", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Principle_of_Least_Astonishment_3" });
            yellow.Principles.Add(new CleanCodePrinciple { Name = "Information Hiding Principle", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Information_Hiding_Principle_4" });
            yellow.Practices.Add(new CleanCodePractice { Name = "Automatisierte Unit Tests", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Automatisierte_Unit_Tests_5" });
            yellow.Practices.Add(new CleanCodePractice { Name = "Mockups (Testattrappen)", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Mockups_Testattrappen_6" });
            yellow.Practices.Add(new CleanCodePractice { Name = "Code Coverage Analyse", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Code_Coverage_Analyse_7" });
            yellow.Practices.Add(new CleanCodePractice { Name = "Teilnahme an Fachveranstaltungen", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Teilnahme_an_Fachveranstaltungen_8" });
            yellow.Practices.Add(new CleanCodePractice { Name = "Komplexe Refaktorisierungen", Link = "http://www.clean-code-developer.de/Gelber-Grad.ashx#Komplexe_Refaktorisierungen_9" });

            var green = NewRank(Colors.Green, "5. Grad");
            green.Principles.Add(new CleanCodePrinciple { Name = "Open Closed Principle", Link = "http://www.clean-code-developer.de/Gr%c3%bcner-Grad.ashx#Open_Closed_Principle_0" });
            green.Principles.Add(new CleanCodePrinciple { Name = "Tell, don´t ask", Link = "http://www.clean-code-developer.de/Gr%c3%bcner-Grad.ashx#Tell_don´t_ask_1" });
            green.Principles.Add(new CleanCodePrinciple { Name = "Law of Demeter", Link = "http://www.clean-code-developer.de/Gr%c3%bcner-Grad.ashx#Law_of_Demeter_2" });
            green.Practices.Add(new CleanCodePractice { Name = "Continuous Integration", Link = "http://www.clean-code-developer.de/Gr%c3%bcner-Grad.ashx#Continuous_Integration_3" });
            green.Practices.Add(new CleanCodePractice { Name = "Statische Codeanalyse (Metriken)", Link = "http://www.clean-code-developer.de/Gr%c3%bcner-Grad.ashx#Statische_Codeanalyse_Metriken_4" });
            green.Practices.Add(new CleanCodePractice { Name = "Inversion of Control Container", Link = "http://www.clean-code-developer.de/Gr%c3%bcner-Grad.ashx#Inversion_of_Control_Container_5" });
            green.Practices.Add(new CleanCodePractice { Name = "Erfahrung weitergeben", Link = "http://www.clean-code-developer.de/Gr%c3%bcner-Grad.ashx#Erfahrung_weitergeben_6" });
            green.Practices.Add(new CleanCodePractice { Name = "Messen von Fehlern", Link = "http://www.clean-code-developer.de/Gr%c3%bcner-Grad.ashx#Messen_von_Fehlern_7" });

            var blue = NewRank(Colors.Blue, "6. Grad");
            blue.Principles.Add(new CleanCodePrinciple { Name = "Entwurf und Implementation überlappen nicht", Link = "http://www.clean-code-developer.de/Blauer-Grad.ashx#Entwurf_und_Implementation_überlappen_nicht_0" });
            blue.Principles.Add(new CleanCodePrinciple { Name = "Implementation spiegelt Entwurf", Link = "http://www.clean-code-developer.de/Blauer-Grad.ashx#Implementation_spiegelt_Entwurf_1" });
            blue.Principles.Add(new CleanCodePrinciple { Name = "You Ain´t Gonna Need It (YAGNI)", Link = "http://www.clean-code-developer.de/Blauer-Grad.ashx#You_Ain´t_Gonna_Need_It_YAGNI_2" });
            blue.Practices.Add(new CleanCodePractice { Name = "Continuous Delivery", Link = "http://www.clean-code-developer.de/Blauer-Grad.ashx#Continuous_Delivery_3" });
            blue.Practices.Add(new CleanCodePractice { Name = "Iterative Entwicklung", Link = "http://www.clean-code-developer.de/Blauer-Grad.ashx#Iterative_Entwicklung_4" });
            blue.Practices.Add(new CleanCodePractice { Name = "Komponentenorientierung", Link = "http://www.clean-code-developer.de/Blauer-Grad.ashx#Komponentenorientierung_5" });
            blue.Practices.Add(new CleanCodePractice { Name = "Test first", Link = "http://www.clean-code-developer.de/Blauer-Grad.ashx#Test_first_6" });
        }
    }
}
