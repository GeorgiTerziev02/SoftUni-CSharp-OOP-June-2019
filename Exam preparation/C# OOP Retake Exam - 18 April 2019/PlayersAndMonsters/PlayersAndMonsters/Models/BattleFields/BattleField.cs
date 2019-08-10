using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public BattleField()
        {

        }

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayerException);
            }

            CheckIfPlayerIsBegginner(attackPlayer);

            CheckIfPlayerIsBegginner(enemyPlayer);

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            var attackerPoints = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
            var enemyPoints = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackerPoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPoints);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void CheckIfPlayerIsBegginner(IPlayer player)
        {
            if (player.GetType() == typeof(Beginner))
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }

            }
        }
    }
}
