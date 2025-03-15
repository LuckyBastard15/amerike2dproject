using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Bindings;

namespace Character.Views
{
    [RequireComponent(
        typeof(SpriteRenderer), 
        typeof(Rigidbody2D))]
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private IntBinding moveBinding;
        private Vector2 direction;

        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public Rigidbody2D Rigidbody2D => rb2D;
        public Transform Transform => transform;
       
       public bool FlipSprite
        {
            get => spriteRenderer.flipX;
            set => spriteRenderer.flipX = value;
        }

       public Vector2 Direction => direction;
       public void JumpButtonDown()
       {
           
       }

       public int MoveState
       {
           set => moveBinding.Value = value;
       }

       public void SetDirection(InputAction.CallbackContext ctx)
       {
           direction = ctx.ReadValue<Vector2>();
       }
    }
}