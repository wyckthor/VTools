using UnityEngine;

namespace VHon
{
    public static class Animators
    {
        //===============================================================================================================================
        // animator.Is("stateName");
        //===============================================================================================================================
        public static bool Is(this Animator animator, string _state)
        {
            return animator.GetCurrentAnimatorStateInfo(0).IsName(_state);
        }

        //===============================================================================================================================
        // animator.IsNot("stateName");
        //===============================================================================================================================
        public static bool IsNot(this Animator animator, string _state)
        {
            return !animator.GetCurrentAnimatorStateInfo(0).IsName(_state);
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}