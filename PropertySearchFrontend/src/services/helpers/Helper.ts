import Cookies from 'js-cookie';

export function saveLoginToken(response: any) {
    var encryptToken = response.data.token;
    Cookies.set("apiAccessToken", encryptToken, { expires: 2 / 24 });
}
