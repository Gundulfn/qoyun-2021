interface Interactable
{
    string GetInteractableText();
    bool IsInteractable();
    void Interact(object parameter = null);
}