using System.Threading;
using Character.Models;
using Character.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Character.Controllers
{
    public class CharacterBaseController : ICharacterBaseController
    {
        private ICharacterView characterView;
        private ICharacterData characterData;
        private CancellationTokenRegistration cancellationTokenRegistration;
        
        public CharacterBaseController(ICharacterView characterView, ICharacterData characterData, CancellationToken gameToken)
        {
            this.characterView = characterView;
            this.characterData = characterData;
            cancellationTokenRegistration = gameToken.Register(Dispose);
            
            MovementCycleTask(gameToken).Forget();
        }

        private async UniTask MovementCycleTask(CancellationToken gameToken)
        {
            var transform = characterView.Transform;
            var moveSpeed = 3f;
            
            while (!gameToken.IsCancellationRequested)
            {
                var direction = characterView.Direction;
                var horizontal = direction.x;

                var flipX = characterView.FlipSprite;
                flipX = horizontal < 0 || !(horizontal > 0) && flipX;
                characterView.FlipSprite = flipX;
                characterView.MoveState = Mathf.Abs((int)horizontal);
                
                transform.Translate(direction * moveSpeed * Time.deltaTime);
                await UniTask.NextFrame();
            }
        }

        public void Dispose()
        {
            cancellationTokenRegistration.Dispose();
        }
    }
}