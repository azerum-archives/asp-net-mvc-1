Доработать стартовый проект. 
Реализовать логику, указанную в TODO 

```
[HttpPost]
public ActionResult Register(VM_UserRegister newUser)
{
    if (ModelState.IsValid)
    {

        User user = new User();
        //TODO: Заполнить user данными из VM_UserRegister newUser

        return RedirectToAction("Account", user);
        //TODO: Создать view - Account где отобразить данные из User user
    }
}
```
