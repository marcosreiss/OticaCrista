using Microsoft.AspNetCore.Components;

namespace OticaCrista.Presentation.Components
{
    public partial class ModalComponent : ComponentBase
    {
        #region Props

        [Parameter] public bool IsVisible { get; set; }
        [Parameter] public string Title { get; set; } = string.Empty;
        [Parameter] public RenderFragment? childContent { get; set; }

        #endregion

        public void CloseModal()
        {
            IsVisible = false;
        }
    }
}
