using Microsoft.JSInterop;

namespace TechFlurry.BusinessSite.App.Interops
{
    public interface IFirebaseInterop
    {
        Task InitFirebase();
    }

    public class FirebaseInterop : InteropBase, IFirebaseInterop
    {
        public FirebaseInterop(IJSRuntime jsRuntime) : base("./js/firebase.js", jsRuntime)
        {
        }


        public async Task InitFirebase()
        {
            var module = await Module;
            await module.InvokeVoidAsync("initFirebase");
        }
    }
}
