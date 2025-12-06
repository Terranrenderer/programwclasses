using System;
using System.ComponentModel.DataAnnotations;
using System.Security;
public class GameLoop
{
    private PlayerAtt player;
    private EnemyAtt enemy;

    private Deck playerDeck;
    private Hand playerHand;

    private int turnCount;
    private bool gameActive;

    private const int STARTING_HAND_SIZE = 5;
    private const int CARDS_PER_TURN = 5;

    public GameLoop()
    {
        this.turnCount = 0;
        this.gameActive = false;
    }
 
    public void StartGame()
    {
        Console.WriteLine("GAME STARTUHHH\n");

        player = new PlayerAtt("Hero");
        Console.WriteLine($"Player created: {player.GetName()}");

        enemy = new EnemyAtt("Goblin", "AGGRESSIVE");
        Console.WriteLine($"Enemy encountered: {enemy.GetName()}");

        playerDeck = new Deck();
        InitializeStarterDeck();
        playerDeck.Shuffle();

        playerHand = new Hand(10);

        DrawCards(STARTING_HAND_SIZE);

        Console.WriteLine("LEZ GO");
        gameActive = true;

        RunTurnCycle();
    }

    public void RunTurnCycle()
    {
        while (gameActive)
        {
            turnCount++;
            Console.WriteLine($"turn numbah {turnCount}");

            PlayerTurn();

            if (CheckWinCondition())
            {
                EndGame();
                break;
            }

            EnemyTurn();

            if (CheckWinCondition())
            {
                EndGame();
                break;
            }
        }
    }

    private void PlayerTurn()
    {
        Console.WriteLine("YOUR TURN");

        player.ResetEnergy();
        player.ClearBlock();

        if (turnCount > 1)
        {
            DrawCards(CARDS_PER_TURN);
        }

        enemy.DetermineIntent();
        Console.WriteLine($"Enemy Intent {enemy.GetIntent()}");

        bool turnOngoing = true;
        while (turnOngoing && gameActive)
        {
            DisplayGameState();
            DisplayHand();

            Console.WriteLine("\nActions: [P]lay Card | [E]nd Turn");
            Console.Write("Choose action: ");
            string input = Console.ReadLine()?.ToUpper();
            
            switch (input)
            {
                case "P":
                    PlayCardAction();
                    break;
                case "E":
                    turnOngoing = false;
                    Console.WriteLine("Ending turn");
                    break;
                default:
                    Console.WriteLine("no can do buckaroo");
                    break;
            }
        }
        DiscardHand();
    }

    private void EnemyTurn()
    {
        Console.WriteLine("Enemy Turn");

        enemy.ResetEnergy();

        enemy.ExecuteIntent(player);

        Console.WriteLine("Press Enter to cont.");
        Console.ReadLine();
    }

    private void PlayCardAction()
    {
        Console.Write("Enter card # to play or 0 to cancel");
        if (int.TryParse(Console.ReadLine(), out int cardIndex))
        {
            if (cardIndex == 0)
            {
                return;
            }

            cardIndex--;

            if (playerHand.PlayCard(cardIndex, player, enemy))
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failiure");
            }
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
    private void DrawCards(int count)
    {
      for (int i = 0; i < count; i++)
        {
            if (playerHand.IsFull())
            {
                Console.WriteLine("Full Hand");
                break;
            }

            Card drawnCard = playerDeck.Draw();
            if (drawnCard != null)
            {
                playerHand.AddCard(drawnCard);
            }
        }  
    }
    
    private void DiscardHand()
    {
        List<Card> discarded = playerHand.DiscardHand();
        foreach (Card card in discarded)
        {
            playerDeck.Discard(card);
        }
    }

    private void DisplayGameState()
    {
        Console.WriteLine($"Player: {player.GetHealth()}/{player.GetMaxHealth()} HP | " +
                         $"{player.GetEnergy()}/{player.GetMaxEnergy()} Energy | " +
                         $"Block: {player.GetBlock()}");
        Console.WriteLine($"Enemy: {enemy.GetHealth()}/{enemy.GetMaxHealth()} HP | " +
                         $"Intent: {enemy.GetIntent()}");
        Console.WriteLine($"Deck: {playerDeck.Size()} | Discard: {playerDeck.GetDiscardSize()}");
    }

    private void DisplayHand()
    {
        Console.WriteLine("\nHAND");
        List<Card> cards = playerHand.GetCards();

        if (cards.Count == 0)
        {
            Console.WriteLine("(EMPTY)");
            return;
        }
        for (int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i];
            Console.WriteLine($"{i + 1}. {card.GetName()} ({card.GetEnergyCost()} Energy) - {card.GetDescription()}");
        }
    }

    private void InitializeStarterDeck()
    {
        for (int i = 0; i < 5; i++)
        {
            playerDeck.AddCard(new AttackCard("Strike", "Deal 6 Damage", 1, 6, "Physical"));
        }
        for (int i = 0; i < 4; i++)
        {
            playerDeck.AddCard(new SkillCard("Defend", "Gain 5 block", 1, "Block", 5));
        }    
        playerDeck.AddCard(new AttackCard("Heavy Strike", "Deal 12 damage", 2, 12, "Physical"));        
    }
    public bool CheckWinCondition()
    {
        if (!enemy.IsAlive())
        {
            Console.WriteLine("\nVICTORY!");
            return true;
        }
        
        if (!player.IsAlive())
        {
            Console.WriteLine("You have been defeated...");
            return true;
        }
        
        return false;
    }
    public void EndGame()
    {
        gameActive = false;
        Console.WriteLine($"\nGame ended after {turnCount} turns.");
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}