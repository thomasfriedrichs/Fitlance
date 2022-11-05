import Routing from "./routes";
import AuthContextProvider from "./context/AuthContext";
import Layout from "./components/layout/Layout";

const App = () => {
  return (
      <AuthContextProvider>
        <Layout>
          <Routing/>
        </Layout>
      </AuthContextProvider>
  );
};

export default App;