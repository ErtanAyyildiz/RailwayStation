// Kullanıcıların Yönetimi İçin Controller
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RailwayStation.Entity.Modals;

public class UserController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // Kullanıcı Güncelleme İşlemi
    [HttpPost]
    public async Task<IActionResult> Edit(AppUser model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(Convert.ToString(model.Id));

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // Kullanıcı Silme İşlemi
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(user);
    }
}
