import { Menu } from '@delon/theme';

// ???????????????????????????
export class AppMenus {
    // new
    static Menus: Menu[] = [
        {
            text: "",// ????????????????????????
            i18n: "HomePage",// ???????????????(ABP?????????)
            acl: "",// ??????
            icon: { type: "icon", value: "home" },// ??????
            link: "/app/home", // url ??????
            // hide: true,  // ????????????
            // ...?????????????????????????????? Menu??????
        },
        {
            text: "",
            i18n: "Tenants",
            acl: "Pages.Tenants",
            icon: { type: "icon", value: "team" },
            link: "/app/tenants",
        },
        {
            text: "",
            i18n: "Roles",
            acl: "Pages.Roles",
            icon: { type: "icon", value: "safety" },
            link: "/app/roles",

        },
        {
            text: "",
            i18n: "Users",
            acl: "Pages.Users",
            icon: { type: "icon", value: "user" },
            link: "/app/users",
        },
        {
            text: "",
            i18n: "About",
            icon: { type: "icon", value: "info-circle" },
            link: "/app/about",
        },
    ];
    // old
    // static Menus = [
    //     // ??????
    //     new MenuItem(
    //         'HomePage',
    //         '',
    //         'anticon anticon-home',
    //         '/app/home'
    //     ),
    //     // ??????
    //     new MenuItem(
    //         'Tenants',
    //         'Pages.Tenants',
    //         'anticon anticon-team',
    //         '/app/tenants',
    //     ),
    //     // ??????
    //     new MenuItem(
    //         'Roles',
    //         'Pages.Roles',
    //         'anticon anticon-safety',
    //         '/app/roles',
    //     ),
    //     // ??????
    //     new MenuItem(
    //         'Users',
    //         'Pages.Users',
    //         'anticon anticon-user',
    //         '/app/users',
    //     ),
    //     // ????????????
    //     new MenuItem(
    //         'About',
    //         '',
    //         'anticon anticon-info-circle-o',
    //         '/app/about',
    //     ),
    // ];
}