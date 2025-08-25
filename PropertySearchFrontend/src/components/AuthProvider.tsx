import { createContext, useContext, useEffect, useState, type PropsWithChildren } from "react";
import { logInUser } from "../services/property/PropertyServices";
import { saveLoginToken } from "../services/helpers/Helper";
import Cookies from 'js-cookie';
import { toast } from "react-toastify";

type Authcontext = {
    authToken?: string | null;
    currentUser?: string | null;
    handleLogin: (payload: { email: string; password: string }) => Promise<boolean>;
    handleLogout: () => Promise<void>;
};

const AuthContext = createContext<Authcontext | undefined>(undefined);
type AuthProviderProps = PropsWithChildren;
export default function AuthProvider({ children }: AuthProviderProps) {

    const [authToken, setAuthToken] = useState<string | null>();
    const [currentUser, setCurrentUser] = useState<string | null>();
  

    useEffect(() => {
        async function fetchUser() {
            try {

                const token = Cookies.get("apiAccessToken") || null;

                if (!token) {
                    setAuthToken(null);
                    setCurrentUser(null);
                    return;
                }

                setAuthToken(token);

                const user = Cookies.get("currentUser") || null;
                setCurrentUser(user);
            } catch {
                setAuthToken(null);
                setCurrentUser(null);
            }
        }

        fetchUser();
    }, []);


    async function handleLogin(payload: { email: string; password: string }) {
        try {
            const response: any = await logInUser(payload)
            if (!response.isSuccess) {
                toast.error(response.errorMessage);
                return false;
            } else {
                setAuthToken(response.data.token);
                setCurrentUser(response.data.email);
                saveLoginToken(response)
                toast.success("Logged in successfully");
                return true;
            }
        } catch (error) {
            setAuthToken(null);
            setCurrentUser(null);
            return false;
        }
    }

    async function handleLogout() {
        setAuthToken(null);
        setCurrentUser(null);
    }

    return <AuthContext.Provider
        value={{
            authToken,
            currentUser,
            handleLogin,
            handleLogout
        }}>
        {children}
    </AuthContext.Provider>
}

export function useAuth() {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error("useAuth must be used within an AuthProvider");
    }
    return context;
}