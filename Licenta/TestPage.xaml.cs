using Licenta.Models;
using Licenta.Services;
using Licenta.ViewModels;
using Licenta.Views;

namespace Licenta;

public partial class TestPage : ContentPage
{
    private List<PetPreference> petPreference;
    private int currentQuestionIndex;
    private int catScore;
    private int dogScore;
    public TestPage()
	{
		InitializeComponent();
        choiceListView.ItemSelected += OnChoiceSelected;
        petPreference = new List<PetPreference>
        {
            new PetPreference
            {
                Question = "Do you prefer spending time indoors or outdoors?",
                Choices = new List<string> { "Indoors", "Outdoors" },
                Scores = new List<int> { 1, -1 }
            },
            new PetPreference
            {
                Question = "How much time do you have to devote to pet care?",
                Choices = new List<string> { "A lot", "Some", "Very little" },
                Scores = new List<int> { 2, 1, -1 }
            },
            new PetPreference
            {
                Question = "When you come home after a long day, what would you want to do?",
                Choices = new List<string> { "Cuddle with your cat", "Play with your dog", "Relax alone" },
                Scores = new List<int> { 2, 1, -1 }
            },
            new PetPreference
            {
                Question = "What is your preferred activity?",
                Choices = new List<string> { "Napping", "Playing catch", "Going for walks" },
                Scores = new List<int> { 2, 1, -1 }
            },
            new PetPreference
            {
                Question = "How do you feel about shedding?",
                Choices = new List<string> { "It's a minor inconvenience", "It's a big problem", "It doesn't bother me" },
                Scores = new List<int> { 2, 1, -1 }
            },
            new PetPreference
            {
                Question = "What is your ideal living situation?",
                Choices = new List<string> { "Living in an apartment with a cat", "Living in a house with a yard and a dog", "Living alone" },
                Scores = new List<int> { 2, 1, -1 }
            },
            new PetPreference
            {
                Question = "What do you consider the most important quality in a pet?",
                Choices = new List<string> { "Independence", "Loyalty", "Low maintenance" },
                Scores = new List<int> { 2, 1, -1 }
            },
        };

        currentQuestionIndex = 0;
        catScore = 0;
        dogScore = 0;
        ShowCurrentQuestion();
    }

    private void ShowCurrentQuestion()
    {
        var currentQuestion = petPreference[currentQuestionIndex];
        questionLabel.Text = currentQuestion.Question;
        choiceListView.ItemsSource = currentQuestion.Choices;
    }

    private void OnChoiceSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedAnswer = e.SelectedItem as string;
        var currentQuestion = petPreference[currentQuestionIndex];
        string preference;
        int scoreForAnswer = currentQuestion.GetScoreForAnswer(selectedAnswer);

        if (currentQuestionIndex == 0)
        {
            catScore = scoreForAnswer;
            dogScore = -scoreForAnswer;
        }
        else
        {
            catScore += scoreForAnswer;
            dogScore -= scoreForAnswer;
        }

        currentQuestionIndex++;

        if (currentQuestionIndex < petPreference.Count)
        {
            ShowCurrentQuestion();
        }
        else
        {
            if (catScore > dogScore)
            {
                preference = "cat person";
            }
            else if (dogScore > catScore)
            {
                preference = "dog person";
            }
            else
            {
                preference = "neutral";
            }

            DisplayAlert("Result", $"You are a {preference}!", "OK"); ;
            Navigation.PopAsync();
        }

    }
}