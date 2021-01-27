namespace Opsive.UltimateInventorySystem.UI.Panels
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DisplayPanelSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Tooltip("The display panel that needs to act as a pop up.")]
        [SerializeField] protected DisplayPanel m_DisplayPanel;
        [SerializeField] protected bool m_SelectOnClick = true;
        [SerializeField] protected bool m_SelectOnHover = true;
        protected void Awake()
        {
            if (m_DisplayPanel == null) { m_DisplayPanel = GetComponent<DisplayPanel>(); }

            if (m_DisplayPanel == null) {
                Debug.LogError("The Display Panel Selector Must reference a Display Panel Manager", gameObject);
                return;
            }
        }

        public virtual void SelectPanel()
        {
            if (m_DisplayPanel.Manager.SelectedDisplayPanel != m_DisplayPanel) {
                m_DisplayPanel.SmartOpen();
            }
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (m_SelectOnClick) { SelectPanel(); }
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (m_SelectOnHover) { SelectPanel(); }
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {

        }
    }


    /*public class DisplayPanelSelector : GraphicRaycasterTarget, IPointerEnterHandler
    {
        [Tooltip("The display panel that needs to act as a pop up.")]
        [SerializeField] protected DisplayPanel m_DisplayPanel;
        [SerializeField] protected bool m_SelectOnClick = true;
        [SerializeField] protected bool m_SelectOnHover;

        private bool m_Initialized = false;
        
        public override bool raycastTarget { 
            get => m_Initialized ? 
                base.raycastTarget && m_DisplayPanel.Manager.SelectedDisplayPanel != m_DisplayPanel :
                base.raycastTarget;
            set => base.raycastTarget = value; 
        }
        
        protected override void Awake()
        {
            if (m_DisplayPanel == null) { m_DisplayPanel = GetComponent<DisplayPanel>(); }

            if (m_DisplayPanel == null) {
                Debug.LogError("The Display Panel Selector Must reference a Display Panel Manager",gameObject);
                return;
            }

            m_Initialized = true;
            
            base.Awake();
        }

        public virtual void SelectPanel()
        {
            if (m_DisplayPanel.Manager.SelectedDisplayPanel != m_DisplayPanel) {
                m_DisplayPanel.SmartOpen();
            }
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if(m_SelectOnClick){ SelectPanel(); }
            

            base.OnPointerClick(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (m_SelectOnHover) { SelectPanel(); } 
        }
    }*/
}